using System;
using System.Security.Cryptography;

namespace Theater.Security
{
    public class Password
    {
        private string rawPassword= string.Empty;
        private string storedPassword = string.Empty;
        private int byteSize;
        private string salt=string.Empty;
        private byte[] saltBytes;
        private string hash=string.Empty;
        private const int ITERATION = 10000;
        public Password(string rawPassword,int byteSize)
        {
            this.rawPassword = rawPassword;
            this.byteSize = byteSize;
            this.GenerateSalt();
            this.GenerateHash();
        }

        public Password(string rawPassword, string storedSalt,string storedPassword)
        {
            this.salt = storedSalt;
            this.storedPassword = storedPassword;
            var saltBytes = Convert.FromBase64String(this.salt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(rawPassword, saltBytes, ITERATION);
            this.hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }

        public string Hash
        {
            get { return this.hash; }
        }

        public string Salt
        {
            get { return this.salt; }
        }

        public string StoredPassword
        {
            get { return this.storedPassword; }
        }

        public bool IsValid
        {
            get { return this.storedPassword == this.hash; }
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
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(this.rawPassword, this.saltBytes, ITERATION);
            this.hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }
    }
}
