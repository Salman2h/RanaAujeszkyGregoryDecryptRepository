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
        private string filepath = "..//..//Test 2 english words _20_.txt";
        public UserInput()
        {
            InitializeComponent();
            plainTextList = Helper.LoadDictionary(filepath);
            keyTable = Helper.InitKeys();
            freqList = Helper.InitFrequency();
        }
        
        private void decryptButton_Click(object sender, EventArgs e)
        {   
            string[] cipherText = cipherTextBox.Text.Split(delimiter);

            if (cipherText.Length == 5)
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
                string plainText = DoDecryption(cipherText, filepath);
                plainTextBox.Text += string.Format("{0}{1}", (plainTextBox.Text.Length > 0) ? "," : "", plainText);
            }
        }

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
    }
}
