using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace покер
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, 
                                                long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private static string POST(string Url, string Data)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
                req.Method = "POST";
                req.Timeout = 100000;
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] sentData = Encoding.GetEncoding("utf-8").GetBytes(Data);
                req.ContentLength = sentData.Length;
                System.IO.Stream sendStream = req.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
                System.Net.WebResponse res = req.GetResponse();
                System.IO.Stream ReceiveStream = res.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
                //Кодировка указывается в зависимости от кодировки ответа сервера
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                string Out = String.Empty;
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    Out += str;
                    count = sr.Read(read, 0, 256);
                }
                return Out;
            }
            catch
            {
                return "";
                MessageBox.Show("хуйня");
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

         /*   System.Threading.Thread.Sleep(5000);
            int x = this.Left;
            int y = this.Top;
            Cursor.Position = new Point(x + 620, y + 299);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                        x, y, 0, 0);
            System.Threading.Thread.Sleep(1000);
            
            Cursor.Position = new Point(x + 620, y + 350);
            System.Threading.Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                        x, y, 0, 0);
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("^a");
            System.Threading.Thread.Sleep(100);
            SendKeys.Send("^c");
            System.Threading.Thread.Sleep(100);
            textBox1.Text = Clipboard.GetText();
            string qww = "log=" + textBox1.Text;
            //label2.Text = qww;*/
            //POST("http://poker.loc/object.php", "log=rabotaet");
            //POST("http://playinfishka.com/object.php", qww);






            timer1.Enabled = true;
           
           // const int x = 32000;
           // const int y = 32000;
           // mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                      //  x, y, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int i;
        int x;
        int y;
        public string[] send  = new string[30];
        string qww;
        private void timer1_Tick(object sender, EventArgs e)
        {
             x = Left;
             y = Top;
            textBox1.Text = "";
            Cursor.Position = new Point(x + 620, y + 299);

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                        x, y, 0, 0);
            System.Threading.Thread.Sleep(50);
            for (i = 1; i <= 15; i++)
            {
                SendKeys.Send("{UP}");
                System.Threading.Thread.Sleep(5);
            }
            System.Threading.Thread.Sleep(500);
            for (i = 1; i <= 20; i++)
            {
                Cursor.Position = new Point(x + 620, y + 299);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                System.Threading.Thread.Sleep(50);
                SendKeys.Send("{DOWN}");
                Cursor.Position = new Point(x + 620, y + 350);
                System.Threading.Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                            x, y, 0, 0);
                System.Threading.Thread.Sleep(100);
                SendKeys.Send("^a");
                System.Threading.Thread.Sleep(100);
                SendKeys.Send("^c");
                System.Threading.Thread.Sleep(100);
                this.send[i] = Clipboard.GetText();
                
            }
            if ((send[15] == send[16]) && (send[16] == send[17]) && (send[17] == send[18]) && (send[18] == send[19]) && (send[19] == send[20]))
            {
                for (i = 1; i <= 20; i++)
                {
                    qww = "log=" + send[i];
                    textBox1.Text += qww;
                    POST("http://playinfishka.com/object.php", qww);
                    System.Threading.Thread.Sleep(100);
                }
            }
            else
            {
                Cursor.Position = new Point(x + 620, y + 299);

                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                            x, y, 0, 0);
                System.Threading.Thread.Sleep(50);
                for (i = 1; i <= 15; i++)
                {
                    SendKeys.Send("{UP}");
                    System.Threading.Thread.Sleep(5);
                }
                System.Threading.Thread.Sleep(500);
                for (i = 1; i <= 20; i++)
                {
                    Cursor.Position = new Point(x + 620, y + 299);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                    System.Threading.Thread.Sleep(50);
                    SendKeys.Send("{DOWN}");
                    Cursor.Position = new Point(x + 620, y + 350);
                    System.Threading.Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP,
                                x, y, 0, 0);
                    System.Threading.Thread.Sleep(100);
                    SendKeys.Send("^a");
                    System.Threading.Thread.Sleep(100);
                    SendKeys.Send("^c");
                    System.Threading.Thread.Sleep(100);
                    send[i] = Clipboard.GetText();
                    
                }
                textBox1.Text = "";
                for (i = 1; i <= 20; i++)
                {
                    qww = "log=" + send[i];
                    textBox1.Text += qww;
                    POST("http://playinfishka.com/object.php", qww);
                    System.Threading.Thread.Sleep(100);
                }

            }
            //textBox1.Text = Clipboard.GetText();
            
            //label2.Text = qww;
            //POST("http://poker.loc/object.php", "log=rabotaet");
            //POST("http://playinfishka.com/object.php", qww);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
