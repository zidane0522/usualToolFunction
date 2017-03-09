using Dapper;
using sidaxin.nots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPwnBySateId
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this);
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            {
                string queryInvalidUser = "select phone from user where isInvalid=1";
                List<string> l = db.Query<string>(queryInvalidUser).ToList();
                File.CreateText(@"D:\无效客户电话.txt");
                string str = "";
                foreach (var item in l)
                {
                    str += item;
                    str += "\n";
                }

                StreamWriter sw = new StreamWriter(@"D:\商标状态.txt");
                sw.Write("");
                sw.Write(str);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string phone = this.textBox1.Text;
            Regex objAlpha = new Regex("/^1[3|4|5|8][0-9]\\d{8}$/");
            if (objAlpha.IsMatch(phone))
            {
                //string strSource = GetUrltoHtml("http://www.ip138.com:8080/search.asp?action=mobile&mobile=13520907750");
                //QueryLocation(strSource);
            }
            string strSource = GetUrltoHtml("http://www.ip138.com:8080/search.asp?action=mobile&mobile=13696523876");
        }

        //private void QueryLocation(string strSource)
        //{
        //    Xmldo
        //}

        private string GetUrltoHtml(string url)
        {
            WebRequest wrt= WebRequest.Create(url);
            WebResponse wrse = wrt.GetResponse();
            Stream strm = wrse.GetResponseStream();
            StreamReader sr = new StreamReader(strm,Encoding.Default);
            string dfds = sr.ReadToEnd();
            String[] d= dfds.Split(new String[]{"卡号归属地"}, StringSplitOptions.None);
            string gsd = d[1].Split('&').First().Split('>').Last();
            string ddd = gsd.Substring(gsd.Length-2,2);
            //WebBrowser wb = new WebBrowser();
            //wb.DocumentText = dfds;
            //this.webBrowser1.DocumentText = dfds;
            //HtmlDocument doc = wb.Document;
            //HtmlElementCollection elems = doc.GetElementsByTagName("META");
            sr.Close();
            return dfds;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EcanSecurity securityCls = new EcanSecurity();
            string a = this.textBox2.Text;
            string b = securityCls.symmetry_Encode(a, "19900522");
            this.textBox2.Text = b;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EcanSecurity securityCls = new EcanSecurity();
            string a = this.textBox2.Text;
            string b = securityCls.symmetry_Decode(a, "19900522");
            this.textBox2.Text = b;
        }
    }
}
