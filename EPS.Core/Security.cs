using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Core
{
    public class Security
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="encryptString">要加密的字符串</param>
        /// <param name="encryptKey">密钥</param>
        /// <returns></returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                var rgbKey = Encoding.ASCII.GetBytes(encryptKey.Substring(0, 8));
                var rgbIV = Keys;
                var inputByteArray = Encoding.ASCII.GetBytes(encryptString);
                var dCSP = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="decryptString">要解密的字符串</param>
        /// <param name="decryptKey">密钥</param>
        /// <returns></returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                var rgbKey = Encoding.ASCII.GetBytes(decryptKey.Substring(0, 8));
                var rgbIV = Keys;
                var strValue = decryptString;
                var inputByteArray = Convert.FromBase64String(strValue);
                var DCSP = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.ASCII.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return decryptString;
            }
        }

        public static string PwdMd5(string pwdstr)
        {
            var cl = pwdstr;
            var newpwd = string.Empty;
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
         

             newpwd = hash.Aggregate(newpwd, (current, t) => current + t.ToString("X"));
             return newpwd;
        }
    }
}
