using System;
using System.Security.Cryptography;

namespace Theater.Security
{
    public class PasswordGenerator
    {
        private string rawPassword;
        private int byteSize;
        private string salt;
        private byte[] saltBytes;
        private string hash;
        public PasswordGenerator(string rawPassword,int byteSize)
        {
            this.rawPassword = rawPassword;
            this.byteSize = byteSize;
            this.GenerateSalt();
            this.GenerateHash();
        }

        public string Salt
        {
            get { return this.salt; }
        }

        public string Hash
        {
            get { return this.hash; }
        }

        private void GenerateSalt()
        {
            this.saltBytes = new byte[this.byteSize];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            this.salt = Convert.ToBase64String(saltBytes);
        }

        private void GenerateHash()
        {
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(this.rawPassword, this.saltBytes, 10000);
            this.hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }
    }
}
