
using Dapper;
using sidaxin.nots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPwnBySateId
{
    public partial class Form1 : Form
    {
        private Form form;

        public Form1(Form f)
        {
            InitializeComponent();
            this.form = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Crypto.GetMD5(this.textBox1.Text);

            List<string> strlist = new List<string>();
            strlist.Add("44");
            strlist.Add("11");
            strlist.Add("22");
            strlist.Add("33");
            strlist.Add("88");

            string t = "33";



            foreach (string item in strlist)
            {
                if (item==t)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string province = "河南省";
            string city = "河南省";
            string distric = "河南省";
            string address = "河南省新乡市牧野区平原路45号院";
            string str3="";
            if (address.Contains(province) || address.Contains(distric) || address.Contains(distric))
             {
                string str1= address.Replace(province, "");
                string str2= str1.Replace(city, "");
                str3= str2.Replace(distric, "");
            }
            this.textBox2.Text = str3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dateStr1 = string.Format("{0:d}", DateTime.Now); ;
            string dateStr2 = DateTime.Now.ToShortTimeString();
            string dateStr3 = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string chineseCode = this.textBox3.Text;
            string PYCode = this.textBox4.Text;
            this.textBox4.Text = ChineseToSpell.ConvertToAllSpell(chineseCode);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox5.Text = CharacterAreaCodingConvertHelper.CharacterToCoding(this.textBox6.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = CharacterAreaCodingConvertHelper.CodingToCharacter(this.textBox5.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            //{
            //    string sql = "select distinct statue from tm_statue ";
            //    List<string> statueList = db.Query<string>(sql).ToList();
            //    File.CreateText(@"D:\商标状态.txt");
            //    string str = "";
            //    foreach (var item in statueList)
            //    {
            //        str += item;
            //        str += "\n";
            //    }
                
            //    StreamWriter sw = new StreamWriter(@"D:\商标状态.txt");
            //    sw.Write("");
            //    sw.Write(str);
            //}
            string guid = Guid.NewGuid().ToString();
        }
        private static string currentTmictm = "";
        private static bool EqualIctm(String s)
        {
            return s == currentTmictm;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string str = "i am {0},you are {2},and He is {0}";
            string sent = string.Format(str,"hh","kk","jj");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form.Show(); 
        }
    }
}
