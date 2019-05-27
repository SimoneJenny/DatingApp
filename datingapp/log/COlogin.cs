using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace datingapp
{
    /*public class COlogin
    {
        private string salted;
        private string hashed;
        private bool loginSucces;

        public void Encrypt(string plaintext)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(plaintext, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashbytes = new byte[36];

            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            string savepasswordHash = Convert.ToBase64String(hashbytes);
            string saltstring = "";
            foreach (var item in salt)
            {
                saltstring = saltstring + item.ToString();
            }
            this.salted = saltstring;
            this.hashed = savepasswordHash;
        }
        public string Saltreturn()
        {
            return salted;
        }
        public string hashReturn()
        {
            return hashed;
        }
        public void validate(string hashed, string inputed)
        {
            Byte[] hashBytes = Convert.ToBase64String(hashed);
            Byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pkdfc2 = new Rfc2898DeriveBytes(inputed, salt, 10000);
            byte[] hash = pkdfc2.GetBytes(20);
            int ok = 1;
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                {
                    ok = 0;
                }

            if (ok == 1)
            {
                loginSucces = true;
            }
            else
            {
                loginSucces = false;
            }
        }
        public bool returnlogin()
        {
            return loginSucces;
        }
    }*/
}
