using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dingdian
{
    class FileUtils
    {
        private static String _FileName = "data.txt";

        //保存数据到文件中        
        public static void SaveFileToText(String currentPagePath)
        {
            //SaveFileDialog file = new SaveFileDialog();//定义新的文件保存位置控件            
            //file.Filter = "txt文件(*.txt)|*.txt";//设置文件后缀的过滤            
            //if (file.ShowDialog() == DialogResult.OK)//如果有文件保存路径            
            //{
            StreamWriter sw = File.CreateText(getSavePath() + _FileName);
            sw.Write(currentPagePath);  //写入文件中                
            sw.Flush();//清理缓冲区                
            sw.Close();//关闭文件            
            //}
        }
        //读取数据       
        public static String ReadFileFormText()
        {
            String str = "" ;
            FileStream fs = new FileStream(getSavePath() + _FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);   //选择编码方式                               
            while (sr.EndOfStream != true)
            {
                str = sr.ReadLine();
            }
            return str;
        }
        //保存地址的绝对路径
        private static String savePath;

        //获取保存路径
        private static String getSavePath()
        {
            if (savePath is null)
            {
                int index = Application.ExecutablePath.LastIndexOf("\\");
                savePath = Application.ExecutablePath.Substring(0, index) + "\\";
            }
            
            return savePath;

        }
    }
}
