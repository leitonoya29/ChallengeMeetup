using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Comu
{
    public class Criptografia
    {
        private const string _encryptPassword = "_PasswordEncriptar*2022";

        public string GetStringSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
       
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            return sb.ToString();
        }

        public string Encrypt(string str)
        {
            var AES = new RijndaelManaged();
            var sh256 = SHA256.Create();
            string ciphertext = "";

            try
            {
                AES.GenerateIV();
                AES.Key = sh256.ComputeHash(Encoding.ASCII.GetBytes(_encryptPassword));
                AES.Mode = CipherMode.CBC;
                ICryptoTransform DESEncrypter = AES.CreateEncryptor();
                var Buffer = Encoding.ASCII.GetBytes(str);
                ciphertext = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                ciphertext = Convert.ToBase64String(AES.IV) + Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
            }

            return ciphertext;
        }

        public string Decrypt(string str)
        {
            var AES = new RijndaelManaged();
            var sh256 = SHA256.Create();
            string strResult = "";
            string iv = "";
            string ciphertext = str.Replace(" ", "+");
         
            try
            {
                var ivct = ciphertext.Split(new[] { "==" }, StringSplitOptions.None);
                iv = ivct[0] + "==";
                ciphertext = ivct.Length == 3 ? ivct[1] + "==" : ivct[1];
                AES.Key = sh256.ComputeHash(Encoding.ASCII.GetBytes(_encryptPassword));
                AES.IV = Convert.FromBase64String(iv);
                AES.Mode = CipherMode.CBC;
                var DESDecrypter = AES.CreateDecryptor();
                var Buffer = Convert.FromBase64String(ciphertext);
                strResult = Encoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
            }

            return strResult;
        }
    }
}
