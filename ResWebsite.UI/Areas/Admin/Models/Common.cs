using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ResWebsite.UI.Areas.Admin.Models
{
    public class Common
    {
        public static string EncryptMD5(string data)
        {
            MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
            byte[] b = System.Text.Encoding.UTF8.GetBytes(data);
            b = myMD5.ComputeHash(b);
            StringBuilder s = new StringBuilder();
            foreach (byte item in b)
            {
                s.Append(item.ToString("X").ToUpper());
            }
            return s.ToString();
        }
    }
}