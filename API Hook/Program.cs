using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace APIHook {
    class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Red;
            var user32 = WinAPI.LoadLibrary("user32.dll");

            if (user32 == IntPtr.Zero) Console.WriteLine("Library not found.");
            else {
                new Hook(
                    WinAPI.GetProcAddress(user32, "MessageBoxW"),
                    Marshal.GetFunctionPointerForDelegate((MessageBoxDelegate)MessageBox)
                ).Enable();

                for (int i = 0; i < 5; i++) {
                    Thread.Sleep(350);
                    System.Windows.Forms.MessageBox.Show("Hello World!");
                }
            }

            Console.ReadKey();
        }

        static int count = 1;
        delegate void MessageBoxDelegate();
        static void MessageBox() => Console.WriteLine($"MessageBox Blocked Count: {count++}");
    }
}
