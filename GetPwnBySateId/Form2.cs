
using Dapper;
using sidaxin.nots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPwnBySateId
{
    public partial class Form2 : Form
    {
        private Form form;
        public Form2(Form f)
        {
            InitializeComponent();
            this.form = f;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DigitToChnText dtct = new DigitToChnText();
            string str1 = this.textBox1.Text;

            this.textBox2.Text = dtct.Convert(str1,false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DigitToChnText dtct = new DigitToChnText();
            string str1 = this.textBox1.Text;

            this.textBox2.Text = dtct.Convert(str1,true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = UrlEncode(this.textBox3.Text, "UTF-8");
        }

        public static string UrlEncode(string str, string encode)
        {
            int factor=5;
            if (encode == "UTF-8")
                factor = 3;
            if (encode == "GB2312")
                factor = 2;
            //不需要编码的字符
            string okChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-*@";
            System.Text.Encoder encoder = System.Text.Encoding.GetEncoding(encode).GetEncoder();
            char[] c1 = str.ToCharArray();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //一个字符一个字符的编码
            for (int i = 0; i < c1.Length; i++)
            {
                //不需要编码
                if (okChar.IndexOf(c1[i]) > -1)
                    sb.Append(c1[i]);
                else
                {
                    byte[] c2 = new byte[factor];
                    int charUsed, byteUsed; bool completed;

                    encoder.Convert(c1, i, 1, c2, 0, factor, true, out charUsed, out byteUsed, out completed);

                    foreach (byte b in c2)
                    {
                        if (b != 0)
                            sb.AppendFormat("%{0:X}", b);
                    }
                }
            }
            return sb.ToString().Trim();


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox5.Text = UrlEncode(this.textBox3.Text, "GB2312");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string base64 = "";
            using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            {
                string sql = "select content from tm_files where id=1404";
                base64 = db.Query<string>(sql).First().Substring(23);
            }
            //string base64 = this.textBox6.Text;
            long ds = base64.Length;
            BASE64_Image_Convert bic = new BASE64_Image_Convert();
            bic.Base64StringToImage(@"D:\th.jpg", base64);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.image = GetImageFromBase64String(this.textBox6.Text);
        }

        private Image GetImageFromBase64String(string ImageText)
        {
            if (ImageText.Length>0)
            {
                byte[] bitmapData = new byte[ImageText.Length];
                bitmapData = Convert.FromBase64String(ImageText);
                System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
                return Image.FromStream(streamBitmap);
            }
            else
            {
                return null;
            }
        }

        private string GetBase64String(System.Drawing.Image image)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] buffer = ms.ToArray();
            return Convert.ToBase64String(buffer);
        }

        private Image image { get; set; }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox6.Text = GetBase64String(image);
        }
    }
}
