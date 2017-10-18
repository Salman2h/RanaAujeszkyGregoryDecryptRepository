using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Rana_Aujeszky_Gregory_Decrypt.BusinessLogic
{
    public class Helper
    {
        private const string keyString = " ,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        private static string KeyCodes = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z, ";
        public enum MaxFrequencyMap
        {
            space = 19,
            a = 7,
            b = 1,
            c = 2,
            d = 4,
            e = 10,
            f = 2,
            g = 2,
            h = 5,
            i = 6,
            j = 1,
            k = 1,
            l = 3,
            m = 2,
            n = 6,
            o = 6,
            p = 2,
            q = 1,
            r = 5,
            s = 5,
            t = 7,
            u = 2,
            v = 1,
            w = 2,
            x = 1,
            y = 2,
            z = 1
        }

        private enum SmallMaxFrequencyMap
        {
            space = 2,
            a = 1,
            b = 1,
            c = 2,
            d = 2,
            e = 1,
            f = 2,
            g = 2,
            h = 5,
            i = 6,
            j = 1,
            k = 1,
            l = 3,
            m = 2,
            n = 0,
            o = 6,
            p = 2,
            q = 1,
            r = 0,
            s = 5,
            t = 7,
            u = 2,
            v = 1,
            w = 2,
            x = 1,
            y = 2,
            z = 1
        }
        
        
        public static List<string> LoadDictionary(string filePath)
        {
            List<string> dictionaryItems = new List<string>();
            dictionaryItems = File.ReadAllLines(filePath).ToList();
            return dictionaryItems;
        }
        public static Hashtable InitFrequency()
        {
            Hashtable result = new Hashtable();
            foreach (string ch in keyString.Split(','))
            {
                result.Add(ch, (int)Enum.Parse(typeof(MaxFrequencyMap), Convert.ToString((ch == " " ? "space" : ch))));
            }
            return result;
        }
        public static Hashtable InitKeys()
        {
            Hashtable result = new Hashtable();
            foreach (string ch in keyString.Split(','))
            {
                result.Add(ch, new ArrayList());
            }
            return result;
        }

        // Dictionary methods

        public static Hashtable GetCharTable()
        {
            Hashtable result = new Hashtable();
            foreach (string ch in KeyCodes.Split(','))
                result.Add(ch, new ArrayList());
            return result;
        }

        public static Hashtable GetKeyCodes(Type frequencyType)
        {
            Hashtable result = new Hashtable();
            foreach (string ch in Helper.KeyCodes.Split(','))
                result.Add(ch, ((int)Enum.Parse(frequencyType, (ch == " ") ? "space" : ch)));
            return result;
        }

        public static string[] GetDictionary(string fileName)
        {
            StreamReader srFile = File.OpenText(fileName);
            string content = srFile.ReadToEnd().Replace("\r", "");
            string[] result = content.Split('\n');
            srFile.Close();
            srFile.Dispose();
            srFile = null;
            return result;
        }
    }
}

