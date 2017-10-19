using System;
using System.Collections;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Rana_Aujeszky_Gregory_Decrypt.BusinessLogic;

namespace Rana_Aujeszky_Gregory_Decrypt
{
    public partial class UserInput : Form
    {
        private char delimiter=',';
        private List<string> plainTextList;
        private Hashtable keyTable;
        private Hashtable freqList;
        //private string filepath = "..//..//Test 1 Candidate Plaintexts Basic.txt";
        //private string filepath = "..//..//Test 2 english words _20_.txt";
        private string filepath;
        public UserInput()
        {
            InitializeComponent();
            filepath = "";
            
            keyTable = Helper.InitKeys();
            freqList = Helper.InitFrequency();
        }
        
        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(filepath))
            {
                MessageBox.Show("Please load dictionary first", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);              
                return;
            }

            plainTextList = Helper.LoadDictionary(filepath);
            string[] cipherText = cipherTextBox.Text.Split(delimiter);

            if (plainTextList.Count == 5)
            {
                foreach (string plainText in plainTextList)
                {
                    foreach (string key in keyTable.Keys)
                    {
                        ((ArrayList)keyTable[key]).Clear();
                    }

                    bool isMatched = true;
                    if (plainText.Length == cipherText.Length)
                    {
                        for (int index = 0; index < cipherText.Length && isMatched; index++)
                        {
                            string aKey = plainText.Substring(index, 1);
                            ArrayList aList = ((ArrayList)keyTable[aKey]);
                            int frequency = (int)freqList[aKey];
                            if (aList.Count >= (int)freqList[aKey])
                            {
                                isMatched = false;
                            }
                            else
                            {
                                aList.Add(cipherText[index]);
                            }
                        }
                        if (isMatched)
                        {
                            plainTextBox.Text += string.Format("{0}{1}", (plainTextBox.Text.Length > 0) ? "," : "", plainText);
                            break;
                        }
                    }
                }
            }
            else
            {
                string plainText = DoDecryption(cipherText, filepath, "");
                plainTextBox.Text += string.Format("{0}{1}", (plainTextBox.Text.Length > 0) ? "," : "", plainText);
                             
                if (String.IsNullOrEmpty(plainText)) // if our recursive funtion fails then try to find as much matches with 1 iteration
                {
                    plainText = DoDecryption(cipherText, filepath);
                    plainTextBox.Text += string.Format("{0}{1}", (plainTextBox.Text.Length > 0) ? "," : "", plainText);
                }
            }

            if (plainTextBox.Text[0].ToString() == ",")
            {
                plainTextBox.Text = plainTextBox.Text.Substring(1);
            }
        }

        // Recursive definition in order to find all false positives
        public static string DoDecryption(string[] cipertextList, string filepath, string startAfterThisWord)
        {
            ArrayList result = new ArrayList(); // to add list of possible findings
            string[] dictionary = Helper.GetDictionary(filepath); // list of words from dictionary file.
            Hashtable charFrequency = Helper.GetKeyCodes(typeof(Helper.MaxFrequencyMap)); // to have list of char frequency in hashtable
            Hashtable charList = Helper.GetCharTable(); // to maintain list of codes for each indexed char
            
            Hashtable numList = new Hashtable(); // to maintain list of cipercode with its corresponding letters/chars
            int ciperCharIndex = 0; // to point the index of current cibertext code
            int prevCiperCharIndex = 0; // to maintain the previous index of last found word
            bool shallIContinue2NextWord = true; // to toggle to skip the main dictionary loop when ciperchar index reached last code in cipertext.
            bool reachedStartingWord = false;
            foreach (string word in dictionary) // loop to pick each word in the dictionary list.
            {
                if (string.IsNullOrEmpty(word.Trim())) continue;
                if (!reachedStartingWord)
                {
                    if (string.IsNullOrEmpty(startAfterThisWord)) // first time let it go to the first word in the dictionary.
                        reachedStartingWord = true;
                    else
                    {
                        if (!reachedStartingWord && startAfterThisWord.Equals(word)) // if starting word found then set the flat and move to next word matching
                        {
                            reachedStartingWord = true; continue;
                        }
                        else
                        {
                            if (!reachedStartingWord) continue; // otherwise, move to the next word until finding the matching start-word
                        }
                    }
                }
                shallIContinue2NextWord = true; // always initialize to pick next word
                Hashtable tempNumList = CopyHashtableFrom(numList);
                bool isMatch = true;
                int charLength = 0;
                foreach (char ch in word)
                {
                    charLength++;
                    string key = ch.ToString();
                    string ciperCode = cipertextList[ciperCharIndex];
                    ArrayList charCodeArray = (ArrayList)charList[key];

                    if (!charCodeArray.Contains(ciperCode))
                    {
                        charCodeArray.Add(ciperCode);
                    }

                    if (charCodeArray.Count > (int)charFrequency[key])
                    {
                        isMatch = false; break;
                    }

                    if (tempNumList.ContainsKey(ciperCode))
                    {
                        if (tempNumList[ciperCode].ToString() != key)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    else
                    {
                        tempNumList.Add(ciperCode, key);
                    }
                    if (++ciperCharIndex >= cipertextList.Length)
                    {
                        ciperCharIndex = prevCiperCharIndex;
                        shallIContinue2NextWord = false;
                        break;
                    }
                }
                if (charLength < word.Length) // if matched chars count of the word is not matching with length of that word, then ignore the matching and proceed to next word
                {
                    shallIContinue2NextWord = true;
                    isMatch = false;
                }

                if (isMatch)
                {
                    result.Add(word);
                    Console.WriteLine("Matching Word: {0}", word);
                    foreach (string key in numList.Keys)
                    {
                        Console.Write("[{0},{1}] ", key, numList[key]);
                    }
                    Console.WriteLine("------------------");
                    prevCiperCharIndex = ciperCharIndex;
                    numList = CopyHashtableFrom(tempNumList);
                }
                else
                {
                    ciperCharIndex = prevCiperCharIndex;
                    foreach (string key in charList.Keys)
                    {
                        ArrayList arrayOfCharList = ((ArrayList)charList[key]);
                        arrayOfCharList.Clear();
                        foreach (string numKey in numList.Keys)
                        {
                            if (numList[numKey].ToString().Equals(key))
                            {
                                arrayOfCharList.Add(numKey);
                            }
                        }
                    }

                }
                if (!shallIContinue2NextWord) break;
            }
            string nextStartingNewWord = "";
            string resultString = string.Empty;
            foreach (string word in result)
            {
                if (string.IsNullOrEmpty(nextStartingNewWord)) nextStartingNewWord = word;
                resultString += word;
            }
            if (resultString.Length != cipertextList.Length) resultString = "";
            if (result.Count == 0)
                return resultString;
            else
                return string.Format("{0}{2}{1}",DoDecryption(cipertextList, filepath, nextStartingNewWord),resultString, (string.IsNullOrEmpty(resultString)?"":",")) ;
        }

        // Non Recursive definition
        public static string DoDecryption(string[] cipertextList, string filepath)
        {
            ArrayList result = new ArrayList(); // to add list of possible findings
            string[] dictionary = Helper.GetDictionary(filepath); // list of words from dictionary file.
            Hashtable charFrequency = Helper.GetKeyCodes(typeof(Helper.MaxFrequencyMap)); // to have list of char frequency in hashtable
            Hashtable charList = Helper.GetCharTable(); // to maintain list of codes for each indexed char

            Hashtable numList = new Hashtable(); // to maintain list of cipercode with its corresponding letters/chars
            int ciperCharIndex = 0; // to point the index of current cibertext code
            int prevCiperCharIndex = 0; // to maintain the previous index of last found word
            bool shallIContinue2NextWord = true; // to toggle to skip the main dictionary loop when ciperchar index reached last code in cipertext.

            foreach (string word in dictionary) // loop to pick each word in the dictionary list.
            {
                shallIContinue2NextWord = true; // always initialize to pick next word
                Hashtable tempNumList = CopyHashtableFrom(numList);
                bool isMatch = true;
                foreach (char ch in word)
                {
                    string key = ch.ToString();
                    string ciperCode = cipertextList[ciperCharIndex];
                    ArrayList charCodeArray = (ArrayList)charList[key];

                    if (!charCodeArray.Contains(ciperCode))
                    {
                        charCodeArray.Add(ciperCode);
                    }

                    if (charCodeArray.Count > (int)charFrequency[key])
                    {
                        isMatch = false; break;
                    }

                    if (tempNumList.ContainsKey(ciperCode))
                    {
                        if (tempNumList[ciperCode].ToString() != key)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    else
                    {
                        tempNumList.Add(ciperCode, key);
                    }
                    if (++ciperCharIndex >= cipertextList.Length)
                    {
                        ciperCharIndex = prevCiperCharIndex;
                        shallIContinue2NextWord = false;
                        break;
                    }
                }
                if (isMatch)
                {
                    result.Add(word);
                    Console.WriteLine("Matching Word: {0}", word);
                    foreach (string key in numList.Keys)
                    {
                        Console.Write("[{0},{1}] ", key, numList[key]);
                    }
                    Console.WriteLine("------------------");
                    prevCiperCharIndex = ciperCharIndex;
                    numList = CopyHashtableFrom(tempNumList);
                }
                else
                {
                    ciperCharIndex = prevCiperCharIndex;
                    foreach (string key in charList.Keys)
                    {
                        ArrayList arrayOfCharList = ((ArrayList)charList[key]);
                        arrayOfCharList.Clear();
                        foreach (string numKey in numList.Keys)
                        {
                            if (numList[numKey].ToString().Equals(key))
                            {
                                arrayOfCharList.Add(numKey);
                            }
                        }
                    }

                }
                if (!shallIContinue2NextWord) break;
            }
            string resultString = string.Empty;
            foreach (string word in result)
            {
                resultString += word;
            }
            return resultString;
        }

        public static Hashtable CopyHashtableFrom(Hashtable hTable)
        {
            Hashtable result = new Hashtable();
            foreach (string numKey in hTable.Keys)
            {
                result.Add(numKey, hTable[numKey]);
            }
            return result;
        }
        
        private void cbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbDelimiter.Text)
            {
                case "Tab":
                    delimiter = '\t';
                    break;
                case "Comma":
                    delimiter = ',';
                    break;
                case "Space":
                    delimiter = ' ';
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loadDictionaryButton_Click(object sender, EventArgs e)
        {
            txtDictFileName.Text = "";
            OpenFileDialog fDialog = new OpenFileDialog();
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtDictFileName.Text = fDialog.FileName;
                filepath = txtDictFileName.Text;
            }
        }
    }
}
