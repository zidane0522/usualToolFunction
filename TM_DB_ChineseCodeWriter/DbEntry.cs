using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace sidaxin.common
{
    public static class DbEntry
    {
       
        static string myConnectionString;
        static DbEntry()
        {
            try
            {
                var s = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                myConnectionString = s;
            }
            catch
            { 

            }            
        }

        public static IDbConnection MySqlDb()
        {
            return new MySqlConnection(myConnectionString);
        }

        public static IDbConnection MySqlDb(string name)
        {
            var myConnectionString = "Server =192.168.1.18; Database =alibb_tm;character set=utf8; uid=root; pwd =amituofo; Pooling=true; Max Pool Size=5;Min Pool Size=2;Allow Batch=true;Allow User Variables=True;"; 
            return new MySqlConnection(myConnectionString);
        }
    }
}
     



