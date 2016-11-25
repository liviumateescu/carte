using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Ch05_HackNotepad
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, string lpString);

        static void Main(string[] args)
        {
            Console.WriteLine("enbter message: ");
            string message = Console.ReadLine();
            Console.WriteLine("press any key to start notepad: ");
            Console.ReadKey();
            Process.Start("notepad.exe").WaitForInputIdle();
            IntPtr notepad = FindWindow("Notepad", null);
            if (notepad != IntPtr.Zero)
            {
                SetWindowText(notepad, "notepad has been hacked!" + message);
            }
            else
            {
                Console.WriteLine("notepad is not runnign");
            }
    }
    }
}
