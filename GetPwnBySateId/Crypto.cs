using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GetPwnBySateId
{
    public static class Crypto
    {
        public static string GetMD5(string source)
        {
            string result = "";
            try
            {
                MD5 getmd5 = new MD5CryptoServiceProvider();
                byte[] targetStr = getmd5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(source));
                result = BitConverter.ToString(targetStr).Replace("-", "");
                return result;
            }
            catch (Exception)
            {
                return "0";
            }

        }


        //解密


        public static string Decode(string data, string Key_64, string Iv_64)


        {


            string KEY_64 = Key_64;// "VavicApp";密钥


            string IV_64 = Iv_64;// "VavicApp"; 向量


            try


            {


                byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);


                byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);


                byte[] byEnc;


                byEnc = Convert.FromBase64String(data); //把需要解密的字符串转为8位无符号数组


                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();


                MemoryStream ms = new MemoryStream(byEnc);


                CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);


                StreamReader sr = new StreamReader(cst);


                return sr.ReadToEnd();


            }


            catch (Exception x)


            {


                return x.Message;


            }


        }


    }
}
