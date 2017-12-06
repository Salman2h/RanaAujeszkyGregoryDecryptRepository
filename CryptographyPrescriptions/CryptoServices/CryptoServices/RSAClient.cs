using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;


namespace CryptoServices
{

    public class RSAPubKeyClient
    {
        private RSACryptoServiceProvider csp;

        public RSAPubKeyClient(RSAParameters p)
        {
            this.csp = new RSACryptoServiceProvider();
            this.csp.ImportParameters(p);
        }

        public byte[] Encrypt(byte[] plaintext)
        {
            return this.csp.Encrypt(plaintext, true);
        }
    }

    public class RSAPrivKeyClient
    {
        private RSACryptoServiceProvider csp;

        public RSAPrivKeyClient(int bits = 2048)
        {
            this.csp = new RSACryptoServiceProvider(bits);
        }

        public RSAParameters PublicParameters
        {
            get
            {
                return this.csp.ExportParameters(false);
            }
        }

        public byte[] Encrypt(byte[] plaintext)
        {
            return this.csp.Encrypt(plaintext, true);
        }

        public byte[] Decrypt(byte[] ciphertext)
        {
            return this.csp.Decrypt(ciphertext, true);
        }
    }

}