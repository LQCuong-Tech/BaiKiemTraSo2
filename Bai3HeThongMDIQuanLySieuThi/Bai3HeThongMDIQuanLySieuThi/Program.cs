using System;
using System.Windows.Forms;

namespace Bai3HeThongMDIQuanLySieuThi.Forms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}