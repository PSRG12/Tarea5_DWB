using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace Tarea5_DWB.Modelos
{
    public class EncryptSC
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static string crearSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}
