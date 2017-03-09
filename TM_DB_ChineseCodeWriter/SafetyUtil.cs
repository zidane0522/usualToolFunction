using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace sidaxin.common
{
    public class SafetyUtil
    {
        private bool ValidateQuery(string queryConditions)
        {
            
            //构造SQL的注入关键字符
            #region 字符
            string[] strBadChar = {"and"
    ,"exec"
    ,"insert"
    ,"select"
    ,"delete"
    ,"update"
    ,"count"
    ,"or"
    //,"*"
    ,"%"
    ,":"
    ,"\'"
    ,"\""
    ,"chr"
    ,"mid"
    ,"master"
    ,"truncate"
    ,"char"
    ,"declare"
    ,"SiteName"
    ,"net user"
    ,"xp_cmdshell"
    ,"/add"
    ,"exec master.dbo.xp_cmdshell"
    ,"net localgroup administrators"};
            #endregion
            //构造正则表达式
            string str_Regex = ".*(";
            for (int i = 0; i < strBadChar.Length - 1; i++)
            {
                str_Regex += strBadChar + "|";
            }
            str_Regex += strBadChar[strBadChar.Length - 1] + ").*";
            //避免查询条件中_list情况
            //foreach (string str in queryConditions.Key)
            //{
            //    if (str.Substring(str.Length - 5) == "_list")
            //    {
            //        //去掉单引号检验
            //        str_Regex = str_Regex.Replace("|'|", "|");
            //    }
            //    string tempStr = queryConditions[str].ToString();
            //    if (Regex.Matches(tempStr.ToString(), str_Regex).Count > 0)
            //    {
            //        //有SQL注入字符
            //        return true;
            //    }
            //}
            //if (Regex.Matches(queryConditions, str_Regex).Count > 0)
            //{
            //    //有SQL注入字符
            //    return true;
            //}
            return false;
        }

    }
}
