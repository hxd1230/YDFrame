using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace YDFrame.Common
{
    public static class EncryptUtil
    {
        public static string Md5(string str)
        {
            return Md5(Encoding.UTF8.GetBytes(str));
        }
        public static string Md5(byte[] data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public static string GetDefaultPwd()
        {
            return Md5("123456");
        }
    }
}
