using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Services;

// Added for Cryptography
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace CryptoServices
{
    /// <summary>
    /// Summary description for SecureMe
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SecureMe : System.Web.Services.WebService
    {

        [WebMethod]
        public string SHA512HashPassword(string password)
        {
            // https://stackoverflow.com/questions/11367727/how-can-i-sha512-a-string-in-c
            byte[] cryptoByte = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hash;
            string hashedPassword = "";
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(cryptoByte);
            }

            hashedPassword = Convert.ToBase64String(hash, 0, hash.Length);            
            return hashedPassword;
        }


        [WebMethod]
        public string AESEncrypt(string input, string key)
        {
            // https://www.codeproject.com/articles/769741/csharp-aes-bits-encryption-library-with-salt
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(key);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }


        [WebMethod]
        public string AESDecrypt(string input, string key)
        {
            // https://www.codeproject.com/articles/769741/csharp-aes-bits-encryption-library-with-salt

            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(key);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        // RSA

        [WebMethod]
        public string RSADecrypt(string encryptedText)
        {          
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            RSAPrivKeyClient rSAPrivKeyClient = new RSAPrivKeyClient();
            byte[] bytesDecrypted = rSAPrivKeyClient.Decrypt(bytesToBeDecrypted);
            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        [WebMethod]
        public string RSAEncrypt(string plainText)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);

            RSAPrivKeyClient rSAPrivKeyClient = new RSAPrivKeyClient();
            var pk = rSAPrivKeyClient.PublicParameters;
            
            RSAPubKeyClient rSAPubKeyClient = new RSAPubKeyClient(pk);
            var encrypted = rSAPubKeyClient.Encrypt(bytesToBeEncrypted);                 

            string result = Convert.ToBase64String(encrypted);

            return result;
        }

        [WebMethod]
        public RSAParameters RSAPublicParameters()
        {                    
            RSAPrivKeyClient rSAPrivKeyClient = new RSAPrivKeyClient();
            RSAParameters rSAParameters = rSAPrivKeyClient.PublicParameters;                 
            return rSAParameters;
        }

               
        // private methods


        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private static byte[] GetRandomBytes()
        {
            int saltLength = GetSaltLength();
            byte[] ba = new byte[saltLength];
            RNGCryptoServiceProvider.Create().GetBytes(ba);
            return ba;
        }

        private static int GetSaltLength()
        {
            return 8;
        }

        private void RSAPublic()
        {
            var bob = new RSAPrivKeyClient();
            var pk = bob.PublicParameters;
            var alice = new RSAPubKeyClient(pk);
            var encrypted = alice.Encrypt(new byte[] { 0, 1, 2, 3 });
            var decrypted = bob.Decrypt(encrypted);

            Console.WriteLine(decrypted);

        }

    }
}
