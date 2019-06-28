using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace adminsite.common
{
    /// <summary>
    /// Clase encargada de cifrar información haciendo uso de MD5
    /// </summary>
    public class MD5Calculator
    {

        /// <summary>
        /// Metodo que genera el cifrado de un texto introducido
        /// </summary>
        /// <returns>Retorna un string</returns>
        /// <param name="text">Texto a ser cifrado</param>
        public string generateMD5(string text)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}