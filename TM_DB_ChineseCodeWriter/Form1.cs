using AlibbMain.Controllers;
using Dapper;
using GetPwnBySateId;
using sidaxin.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TM_DB_ChineseCodeWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maxId = 14016623;//Id号最大值
            string currentName = "";
            string currentSpellCode = "";
            try
            {
                using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
                {
                    string QuerySql = "select name from tm_ictm_copy where id=@id";
                    string UpdateSql = "update tm_ictm_copy set name_1=@SpellCode where id=@id;";
                    //var applicantCount = db.Query<int>().First();
                    for (int i = 1; i <= maxId; i++)
                    {
                        var a = db.Query<string>(QuerySql, new { id = i });
                        if (a != null)
                        {
                            if (a.Count() > 0 && !string.IsNullOrEmpty(a.First()))
                            {
                                currentName = a.First();
                                currentSpellCode = ChineseToSpell.ConvertToAllSpell(currentName);
                                var updateName_1 = db.Execute(UpdateSql, new { SpellCode = currentSpellCode, id = i }); 

                                StreamWriter sw = new StreamWriter(@"D:\商标名称转换拼音日志.txt");
                                sw.Write("");
                                string mesg = string.Format("id号：{0}  商标名称：{1}  拼音：{2}", i.ToString(), currentName, currentSpellCode);
                                sw.WriteLine(mesg);
                                this.textBox1.Text = mesg;
                                sw.Close();
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(@"D:\商标名称转换拼音日志.txt");
                sw.WriteLine(string.Format("商标名称转换异常：{0}",ex.Message));
                sw.Close();
                this.textBox1.Text += ex.Message;
                if (ex.Message== "Incorrect key file for table '.\alibb_tm\tm_ictm_copy.MYI'; try to repair it")
                {
                    string repairSql = "repair table tm_ictm_copy;";
                    using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
                    {
                        db.Execute(repairSql);
                        this.textBox1.Text +="数据库修复成功，请继续";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string base64Str = this.textBox2.Text;
                int dds = base64Str.Length;
                //string a = base64Str.Replace("data:image/jpeg;base64,", "");
                string a = base64Str.Replace("data:application/pdf;base64,", "     ");
                //string b = a.Replace("+", "%2B");
                string b = a.Replace("%2B","+");
                int ds = b.Length;
                byte[] data = Convert.FromBase64String(b);
                //string decodedString = Encoding.Unicode.GetString(data);

                // byte[] pdfbyte = System.Text.Encoding.ASCII.GetBytes(content);
                //设置保存的文件名companyId, userId 不用管 是个int 的参数
                //string filename = FileHelper.GenFileName(companyId, userId, "ShipStation_") + ".pdf";
                //保存文件
                using (var mem = new MemoryStream(data))
                {
                    using (var file = new FileStream(@"D:\test.pdf", FileMode.Create, FileAccess.Write))
                    {
                        mem.WriteTo(file);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        private void ToBase64()
        {
            Image img = this.pictureBox1.Image;
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, img);
            byte[] bytes = memStream.GetBuffer();
            string base64 = Convert.ToBase64String(bytes);
            //this.textBox2.Text = base64;
            using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            {
                string sql = "insert into tm_files (fileId,name,content) values (@fileId,@name,@content)";
                db.Execute(sql, new { fileId = "123456", name = "123456", content = base64 });
            }
        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        private void ToImage()
        {
            string base64 = this.textBox2.Text;
            byte[] bytes = Convert.FromBase64String(base64);
            MemoryStream memStream = new MemoryStream(bytes);
            BinaryFormatter binFormatter = new BinaryFormatter();
            Image img = (Image)binFormatter.Deserialize(memStream);
            this.pictureBox1.Image = img;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "选择要转换的图片";
            dlg.Filter = "Image files (*.jpg;*.bmp;*.gif)|*.jpg*.jpeg;*.gif;*.bmp|AllFiles (*.*)|*.*";
            string imgStr = "";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                imgStr = ImgToBase64String(dlg.FileName);
            }
            using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            {
                string sql = "insert into tm_files (fileId,name,content) values (@fileId,@name,@content)";
                db.Execute(sql, new { fileId = "123456", name = "123456", content = imgStr });
            }
        }

        //图片 转为    base64编码的文本  
        private string ImgToBase64String(string Imagefilename)
        {
            string strbaser64 = "";
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                this.pictureBox1.Image = bmp;
                FileStream fs = new FileStream(Imagefilename + ".txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                strbaser64 = Convert.ToBase64String(arr);
                int ds = strbaser64.Length;
                sw.Write(strbaser64);

                sw.Close();
                fs.Close();
                MessageBox.Show("转换成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败/nException:" + ex.Message);
            }
            return strbaser64;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 3;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "选择要转换的文件";
            //dlg.Filter = "Image files (*.jpg;*.bmp;*.gif)|*.jpg*.jpeg;*.gif;*.bmp|AllFiles (*.*)|*.*";
            string Str = "";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                Str = dlg.FileName;
            }
            byte[] buffer = ConvertToBinary(Str);


            using (var db = DbEntry.MySqlDb(SqlConst.DB_NAME_ALBBWEB))
            {
                //string sql = "insert into tm_files (fileId,name,contractContent) values (@fileId,@name,@contractContent)";
                //db.Execute(sql, new { fileId = "123456", name = "123456", contractContent = buffer });

                string sql = "select contractContent from tm_files where id=@id";
                var feer= db.Query(sql,new { id =1428}).First();
                byte[] fe = feer.contractContent;
                ConvertToPdf(fe);
            }
            ConvertToPdf(buffer);
        }


        public static byte[] ConvertToBinary(string Path)
        {

            FileStream stream = new FileInfo(Path).OpenRead();

            byte[] buffer = new byte[stream.Length];

            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));

            return buffer;

        }

        public void ConvertToPdf(byte[] buffer)
        {
            string filePath = "D:\\afd.pdf";   //文件路径
            //byte[] br = ConvertToBinary(filePath);
            FileStream fstream = File.Create(filePath, buffer.Length);
            try
            {
                fstream.Write(buffer, 0, buffer.Length);   //二进制转换成文件
            }
            catch (Exception ex)
            {
                //抛出异常信息
            }
            finally
            {
                fstream.Close();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
