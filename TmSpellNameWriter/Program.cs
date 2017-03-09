using AlibbMain.Controllers;
using Dapper;
using GetPwnBySateId;
using sidaxin.nots;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmSpellNameWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //int thisId = 0;
            //int maxId = 18819365;//Id号最大值
            ////string currentName = "";
            ////string currentSpellCode = "";
            //try
            //{
            //    using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            //    {
            //        string QuerySql = "select regNum,ictm,name from tm_ictm where id=@id";
            //        string UpdateSql = "insert into tm_ictm_partial (regNum,ictm,name_1) values (@regNum,@ictm,@name_1)";
            //        for (int i = 2000000000; i < 18819356; i++)
            //        {
            //            thisId = i;
            //            var a = db.Query<tm>(QuerySql, new { id = i });
            //            if (a == null || a.Count() == 0)
            //            {
            //                continue;
            //            }
            //            if (a.First() != null)
            //            {
            //                tm s = a.First();
            //                if (s.name==null)
            //                {
            //                    db.Execute(UpdateSql, new { regNum = s.regNum, ictm = s.ictm, name_1 = "" });
            //                }
            //                else
            //                {
            //                    char[] lol = s.name.ToCharArray();
            //                    string fulstr = "";
            //                    foreach (var item in lol)
            //                    {
            //                        fulstr += item.ToString() + " ";
            //                    }
            //                    fulstr = fulstr.Trim();
            //                    fulstr = ChineseToSpell.ConvertToAllSpell(fulstr);
            //                    db.Execute(UpdateSql, new { regNum = s.regNum, ictm = s.ictm, name_1 = fulstr });
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    StreamWriter sw = new StreamWriter(@"D:\商标名称转换拼音日志.txt");
            //    sw.WriteLine(string.Format("商标名称转换异常：{0}", ex.Message));
            //    string mesg = string.Format("id {0}", thisId.ToString());
            //    sw.WriteLine(mesg);
            //    sw.Close();
            //    if (ex.Message == "Incorrect key file for table '.\alibb_tm\tm_ictm_copy.MYI'; try to repair it")
            //    {
            //        string repairSql = "repair table tm_ictm_copy;";
            //        using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            //        {
            //            db.Execute(repairSql);
            //        }
            //    }
            //}
        }

        public void updateApplicant()
        {
            int thisId = 0;
            int maxId = 14016623;//Id号最大值
            //string currentName = "";
            //string currentSpellCode = "";
            try
            {
                using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
                {
                    //string QuerySql = "select name from tm_ictm_copy where id=@id";
                    string QuerySql = "select regNum,ictm,name_1 from tm_ictm_copy where id=@id";
                    //string UpdateSql = "update tm_ictm_applicant set name_1=@SpellCode where id=@id;";
                    string UpdateSql = "insert into tm_ictm_applicant (regNum,ictm,name_1) values (@regNum,@ictm,@name_1)";
                    //var applicantCount = db.Query<int>().First();
                    //for (int i = 1; i <= maxId; i++)
                    //{
                    //    thisId = i;
                    //    var a = db.Query<string>(QuerySql, new { id = i });
                    //    if (!string.IsNullOrEmpty(a.First()))
                    //    {
                    //        currentName = a.First();
                    //        currentSpellCode = ChineseToSpell.ConvertToAllSpell(currentName);
                    //        db.Execute(UpdateSql, new { SpellCode = currentSpellCode, id = i });
                    //    }
                    //}
                    for (int i = 57980; i <= maxId; i++)
                    {
                        thisId = i;
                        var a = db.Query<tm>(QuerySql, new { id = i });
                        if (a.First() != null)
                        {
                            tm s = a.First();
                            db.Execute(UpdateSql, new { regNum = s.regNum, ictm = s.ictm, name_1 = s.name});
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(@"D:\商标名称转换拼音日志.txt");
                sw.WriteLine(string.Format("商标名称转换异常：{0}", ex.Message));
                string mesg = string.Format("id {0}", thisId.ToString());
                sw.WriteLine(mesg);
                sw.Close();
                if (ex.Message == "Incorrect key file for table '.\alibb_tm\tm_ictm_copy.MYI'; try to repair it")
                {
                    string repairSql = "repair table tm_ictm_copy;";
                    using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
                    {
                        db.Execute(repairSql);
                    }
                }
            }
        }

        public void Func_1()
        {
            int thisId = 0;
            int maxId = 14016623;//Id号最大值
        
            try
            {
                using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
                {
                    string QuerySql = "select applicant from tm_ictm_copy where id=@id";
                    for (int i = 13630896; i <= maxId; i++)
                    {
                        thisId = i;
                        var a = db.Query<string>(QuerySql, new { id = i });
                        if (a.First() != null)
                        {
                            if (a.First().Length > 83)
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

//StreamWriter sw = new StreamWriter(@"D:\商标名称转换拼音日志.txt");
//sw.Write("");
//string mesg = string.Format("id {0}", i.ToString());
//sw.WriteLine(mesg);
//sw.Close();
