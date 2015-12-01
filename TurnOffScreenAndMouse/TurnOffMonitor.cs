using System;
using System.Runtime.InteropServices;

namespace TurnOffScreenAndMouse
{
    public static class TurnOffMonitor
    {
        private static int WM_SYSCOMMAND = 0x0112;
        private static uint SC_MONITORPOWER = 0xF170;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public static void Off()
        {
            SendMessage(new IntPtr(0xFFFF), WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)2); 
        }       
    }
}