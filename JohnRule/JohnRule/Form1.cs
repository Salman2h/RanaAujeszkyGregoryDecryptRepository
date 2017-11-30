using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JohnRule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public static List<string> LoadDictionary(string filePath)
        {
            List<string> dictionaryItems = new List<string>();
            dictionaryItems = File.ReadAllLines(filePath).ToList();
            return dictionaryItems;
        }

        private void BuildFirstHalf(string password)
        {

            StreamWriter file;

            string temp = password;
            int aOccurence = password.IndexOf("a");

            string[] aArray;

            aArray = password.Split('a');
            int aCount = aArray.Length - 1;


            string orginalPassword = password;
            for (int i = 0; i < aCount; i++)
            {
                file = new StreamWriter(@"../../newwordlist.txt", true);
                if (i == 0)
                {
                    //write to a file
                    textBoxResult.Text = password;
                    file.WriteLine(password);
                    
                    /* Added for single occurance
                     * 
                                        
                     * */

                    aArray = temp.Split('a');
                    aCount = aArray.Length - 1;

                    string singleOccurance = temp;

                    for (int j = 0; j < aCount; j++)
                    {

                        int aTemp = singleOccurance.IndexOf("a");

                        StringBuilder sbTemp = new StringBuilder(temp);
                        sbTemp[aTemp] = '4';

                        if (j > 0)
                        {
                            textBoxResult.Text = sbTemp.ToString();
                            file.WriteLine(sbTemp.ToString());                            
                        }

                        StringBuilder sbSingleOccurance = new StringBuilder(singleOccurance);
                        sbSingleOccurance[aTemp] = '4';
                        singleOccurance = sbSingleOccurance.ToString();

                    }



                    // End single occurance

                }

                int aIndex = password.IndexOf("a");

                StringBuilder sb = new StringBuilder(password);
                sb[aIndex] = '4';
                password = sb.ToString();

                //write to a file
                textBoxResult.Text = password;
                file.WriteLine(password);
                file.Close();
            }
        }

        private void BuildSecondHalf(string password)
        {
            // teamst3rs
            // te4mst3rs
            StreamWriter file;

            string temp = password;

            string[] eArray;
            eArray = password.Split('e');
            int eCount = eArray.Length - 1;
            string orginalPassword = password;

            temp = orginalPassword;
            for (int i = 0; i < eCount; i++)
            {

                int aIndex = password.IndexOf("e");

                StringBuilder sb = new StringBuilder(password);
                sb[aIndex] = '3';
                password = sb.ToString();

                int aOrginalIndex = orginalPassword.IndexOf("e");

                StringBuilder sbOriginal = new StringBuilder(orginalPassword);
                sbOriginal[aOrginalIndex] = '3';
                orginalPassword = sbOriginal.ToString();

                file = new StreamWriter(@"../../newwordlist.txt", true);

                if (i == 0)
                {
                    eArray = temp.Split('e');
                    eCount = eArray.Length - 1;

                    string singleOccurance = temp;

                    for (int j = 0; j < eCount; j++)
                    {

                        int aTemp = singleOccurance.IndexOf("e");

                        StringBuilder sbTemp = new StringBuilder(temp);
                        sbTemp[aTemp] = '3';

                        if (j > 0)
                        {
                            textBoxResult.Text = sbTemp.ToString();
                            file.WriteLine(sbTemp.ToString());
                        }

                        StringBuilder sbSingleOccurance = new StringBuilder(singleOccurance);
                        sbSingleOccurance[aTemp] = '3';
                        singleOccurance = sbSingleOccurance.ToString();

                    }
                }

                //write to a file
                textBoxResult.Text = password;
                file.WriteLine(password);
                textBoxResult.Text = orginalPassword;
                file.WriteLine(orginalPassword);
                file.Close();
            }
        }

        private void ButtonGenerateRule_Click(object sender, EventArgs e)
        {

            List<string> plainTextList = LoadDictionary(@"../../wordlist.txt");

            foreach (string plainText in plainTextList)
            {
                StreamWriter file;
                string password = plainText;
                string temp = password;
                int aOccurence = password.IndexOf("a");

                string[] aArray;

                aArray = password.Split('a');
                int aCount = aArray.Length - 1;


                string orginalPassword = password;
                for (int i = 0; i < aCount; i++)
                {
                    file = new StreamWriter(@"../../newwordlist.txt", true);
                    if (i == 0)
                    {
                        aArray = temp.Split('a');
                        aCount = aArray.Length - 1;

                        string singleOccurance = temp;

                        for (int j = 0; j < aCount; j++)
                        {

                            int aTemp = singleOccurance.IndexOf("a");

                            StringBuilder sbTemp = new StringBuilder(temp);
                            sbTemp[aTemp] = '4';

                            if (j > 0)
                            {
                                textBoxResult.Text = sbTemp.ToString();
                                file.WriteLine(sbTemp.ToString());
                            }

                            StringBuilder sbSingleOccurance = new StringBuilder(singleOccurance);
                            sbSingleOccurance[aTemp] = '4';
                            singleOccurance = sbSingleOccurance.ToString();
                        }

                        // End single occurance
                    }

                    int aIndex = password.IndexOf("a");

                    StringBuilder sb = new StringBuilder(password);
                    sb[aIndex] = '4';
                    password = sb.ToString();

                    //write to a file
                    textBoxResult.Text = password;
                    file.WriteLine(password);
                    file.Close();
                }

                // teamst3rs
                // te4mst3rs
                string[] eArray;
                eArray = password.Split('e');
                int eCount = eArray.Length - 1;

                temp = orginalPassword;
                for (int i = 0; i < eCount; i++)
                {
                    int aIndex = password.IndexOf("e");

                    StringBuilder sb = new StringBuilder(password);
                    sb[aIndex] = '3';
                    password = sb.ToString();

                    int aOrginalIndex = orginalPassword.IndexOf("e");

                    StringBuilder sbOriginal = new StringBuilder(orginalPassword);
                    sbOriginal[aOrginalIndex] = '3';
                    orginalPassword = sbOriginal.ToString();

                    file = new StreamWriter(@"../../newwordlist.txt", true);

                    if (i == 0)
                    {
                        eArray = temp.Split('e');
                        eCount = eArray.Length - 1;

                        string singleOccurance = temp;

                        for (int j = 0; j < eCount; j++)
                        {

                            int aTemp = singleOccurance.IndexOf("e");

                            StringBuilder sbTemp = new StringBuilder(temp);
                            sbTemp[aTemp] = '3';

                            if (j > 0)
                            {
                                textBoxResult.Text = sbTemp.ToString();
                                file.WriteLine(sbTemp.ToString());
                            }

                            StringBuilder sbSingleOccurance = new StringBuilder(singleOccurance);
                            sbSingleOccurance[aTemp] = '3';
                            singleOccurance = sbSingleOccurance.ToString();
                        }
                    }

                    //write to a file
                    textBoxResult.Text = password;
                    file.WriteLine(password);
                    textBoxResult.Text = orginalPassword;
                    file.WriteLine(orginalPassword);
                    file.Close();
                }
                BuildFirstHalf(temp.Replace("e", "3"));
                BuildSecondHalf(temp.Replace("a", "4"));
            }
            MessageBox.Show("Wordlist generated!");
        }

    }

  
}
