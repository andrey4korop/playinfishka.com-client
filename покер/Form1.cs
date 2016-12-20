using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace покер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr ptr = WinAPI.FindWindow(null, "Текущая история раздач");

            

            //Если окно найдено, то отбращаемся к его дочерним объектам

            if (ptr.ToInt32() != 0)

            {

                IntPtr[] child = new IntPtr[10];
                IntPtr[] child2 = new IntPtr[5];

                child[0] = WinAPI.GetWindow(ptr, WinAPI.GetWindow_Cmd.GW_CHILD);

                StringBuilder title = new StringBuilder(2000);


                for (int i = 1; i <= 3; i++)

                {
                    
                    child[i] = WinAPI.GetWindow(child[i - 1], WinAPI.GetWindow_Cmd.GW_HWNDNEXT);
                    WinAPI.SendMessage(child[i - 1], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_GETTEXT), (IntPtr)20, title);
                    lbWindows.Items.Add(title.ToString());
                    
                    if (i == 3)
                    {
                        lbWindows.Items.Add("от здесь");
                        child2[0] = WinAPI.GetWindow(child[i-1], WinAPI.GetWindow_Cmd.GW_CHILD);
                        int d= WinAPI.GetWindowTextLength(child2[0]);
                        lbWindows.Items.Add(d.ToString());
                   
                        WinAPI.SendMessage(child2[0], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_GETTEXT), (IntPtr)26, title);
                        lbWindows.Items.Add(title.ToString());
                        WinAPI.GetWindowText(child2[0], title, 20);
                        lbWindows.Items.Add(title.ToString());
                        



                    }
                    

                    

                }




                            


            }


        }
    }

    public static class WinAPI

    {

        ///  <summary>

        ///  Найти окно

        ///  </summary>

        ///  <param name="lpClassName">Имя класса окна</param>

        ///  <param name="lpWindowName">Имя окна</param>

        ///  <returns></returns>

        [DllImport("user32.dll", SetLastError = true)]

        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);



        [DllImport("user32.dll", SetLastError = true)]

        public static extern IntPtr GetWindow(IntPtr HWnd, GetWindow_Cmd cmd);



        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, [Out]  StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);


        public enum GetWindow_Cmd : uint

        {

            GW_HWNDFIRST = 0,

            GW_HWNDLAST = 1,

            GW_HWNDNEXT = 2,

            GW_HWNDPREV = 3,

            GW_OWNER = 4,

            GW_CHILD = 5,

            GW_ENABLEDPOPUP = 6,

            WM_GETTEXT = 0x000D

        }


    }

}
