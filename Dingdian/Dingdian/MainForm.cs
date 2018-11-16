using HtmlAgilityPack;
using LogHelper;
using SQLiteHelpler;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Dingdian
{
    public partial class mainForm : Form
    {
        //private SQLiteHelpler.DianBA dianBA;
        //private Boolean dbReady;
        
        

        public mainForm()
        {
            InitializeComponent();
            
            //SQLiteHelpler.SQLiteUtils.initSQLiteDB();
            //dianBA = new SQLiteHelpler.DianBA();
            //LogFactory.Init();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            String path = FileUtils.ReadFileFormText();
            if (!path.Equals("") && path.Contains("html"))
            {
                displayContent(path);
            }
            else
            {
                displayContent(index);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        String index = "/ddk157755/8482648.html";
        String baseUrl = "https://www.dingdiann.com";
        String prePage = "";
        String nextPage = "";
        String titleName = "";
        int count = 0;

        private void displayContent(String url)
        {
            try
            {
                // The HtmlWeb class is a utility class to get the HTML over HTTP
                HtmlWeb htmlWeb = new HtmlWeb();

                // Creates an HtmlDocument object from an URL
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(baseUrl + url);

                // Targets a specific node
                HtmlNode someNode = document.GetElementbyId("content");

                HtmlNode htmlNode = document.DocumentNode.Element("html");
                HtmlNodeCollection htmlNodes = htmlNode.SelectNodes("/html[1]/body[1]/div[1]/div[4]/div[2]/div[2]/div[1]/a");

                titleName= htmlNode.SelectNodes("/html[1]/head[1]/title[1]")[0].InnerText;

                prePage = "";
                nextPage = "";
                foreach (HtmlNode node in htmlNodes)
                {
                    if (node.Attributes.Contains("href") && node.Attributes["href"].Value.Contains(".html"))
                    {
                        if (prePage.Equals(""))
                        {
                            prePage = node.Attributes["href"].Value;
                            
                        }
                        else
                        {
                            nextPage = node.Attributes["href"].Value;

                        }
                    }
                }

                if (someNode != null)
                {
                    beautyText(someNode.InnerHtml);
                }
                //FileUtils.SaveFileToText(url);
                //dianBA.insert(GetDianData(titleName, nextPage, richTextBox1.Text));
                //LogFactory.LogError("查找车辆错误", "找不到符合条件的AGV小车");
                //LogFactory.LogDispatch("调度ID", "窑尾调度", "调度信息");
                //LogFactory.LogFinish("调度完成ID", "窑头调度", "调度信息");

               /// LogFactory.LogAdd(LOGTYPE.DISPATCH,"","","");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private DianData GetDianData(String name,String url,String data)
        {
            DianData dian = new DianData();
            dian.DianName = name;
            dian.DianUrl = url;
            dian.DianContent = data;
            return dian;
        }

        private void beautyText(String content)
        {

            richTextBox1.Clear();

            richTextBox1.Text = titleName;
            // 1.<br/><br/> 替换 &
            content = content.Replace("\n", "").Replace("\t", "").Replace("\r","").Replace("\t","").Replace("<br><br>", "&");
            //richTextBox1.Text =  content.OuterHtml;
            String[] session = content.Split('&');
            
            if(session != null)
            {
                foreach (String value in session)
                {
                    richTextBox1.Text = richTextBox1.Text + "\n" + value;
                }
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (prePage.Equals(""))
                    {
                        MessageBox.Show("没有获取到上一章的链接");
                    }
                    else
                    {
                        displayContent(prePage);
                    }
                    break;
                case Keys.Right:
                    if (nextPage.Equals(""))
                    {
                        MessageBox.Show("没有获取到下一章的链接");

                    }
                    else
                    {
                        displayContent(nextPage);
                    }
                    break;
                
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
            }
        }

        private void richTextBox1_CursorChanged(object sender, EventArgs e)
        {
            Console.WriteLine(richTextBox1.Cursor);
        }
    }
}
