using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetPwnBySateId
{
    public class BASE64_Image_Convert
    {
        //图片 转为    base64编码的文本
        public void ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                //this.pictureBox1.Image = bmp;
                FileStream fs = new FileStream(Imagefilename + ".txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                sw.Write(strbaser64);

                sw.Close();
                fs.Close();
                // MessageBox.Show("转换成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败\nException:" + ex.Message);
            }
        }

        //base64编码的文本 转为    图片
        public void Base64StringToImage(string txtFileName,string base64)
        {
            try
            {
                //if (File.Exists(txtFileName))
                //{
                //    File.Delete(txtFileName);
                //}


                //FileStream ifs = new FileStream(txtFileName, FileMode.Open, FileAccess.Read);
                //StreamReader sr = new StreamReader(ifs);

                //String inputStr = sr.ReadToEnd();
                byte[] arr = Convert.FromBase64String(base64);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                bmp.Save(txtFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save(txtFileName + ".bmp", ImageFormat.Bmp);
                //bmp.Save(txtFileName + ".gif", ImageFormat.Gif);
                //bmp.Save(txtFileName + ".png", ImageFormat.Png);
                ms.Close();
                //sr.Close();
                //ifs.Close();
                //this.pictureBox2.Image = bmp;
                //if (File.Exists(txtFileName))
                //{
                //    File.Delete(txtFileName);
                //}
                //MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Base64StringToImage 转换失败\nException：" + ex.Message);
            }
        }

    }
}
