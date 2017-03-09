using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPwnBySateId
{
    public class CharacterAreaCodingConvertHelper
    {
        /// <summary>
        /// 汉字转区位码
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string CharacterToCoding(string character)
        {
            string coding = string.Empty;
            for (int i = 0; i < character.Length; i++)
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(character.Substring(i, 1));
                string lowCode = System.Convert.ToString(bytes[0], 16); //取出低字节编码内容（两位16进制）
                if (lowCode.Length == 1)
                    lowCode = "0" + lowCode;
                string hightCode = System.Convert.ToString(bytes[1], 16);//取出高字节编码内容（两位16进制）
                if (hightCode.Length == 1)
                    hightCode = "0" + hightCode;
                coding += (lowCode + hightCode);//加入到字符串中,
            }
            return coding;
        }

        /// <summary>
        /// 区位码取汉字
        /// </summary>
        /// <param name="coding"></param>
        /// <returns></returns>
        public static string CodingToCharacter(string coding)
        {
            string characters = string.Empty;
            if (coding.Length % 4 != 0)//编码为16进制,必须为4的倍数。
            {
                throw new System.Exception("编码格式不正确");
            }
            for (int i = 0; i < coding.Length / 4; i++)
            {
                byte[] bytes = new byte[2];
                int j = i * 4;
                string lowCode = coding.Substring(j, 2); //取出低字节,并以16进制进制转换
                bytes[0] = System.Convert.ToByte(lowCode, 16);
                string highCode = coding.Substring(j + 2, 2); //取出高字节,并以16进制进行转换
                bytes[1] = System.Convert.ToByte(highCode, 16);
                string character = System.Text.Encoding.GetEncoding("GB2312").GetString(bytes);
                characters += character;
            }
            return characters;
        }
    }
}
