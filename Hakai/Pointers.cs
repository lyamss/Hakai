using System.Runtime.InteropServices;

namespace Hakai
{
    public class Pointers
    {
        unsafe static void bufferOverflow(string s)
        {
            char* ptr = stackalloc char[10];
            int i = 0;

            while (i < s.Length && i < 10)
            {
                *ptr++ = s[i];
                i++;
            }
        }

        public unsafe static void WoW()
        {
            int* buffer = (int*)Marshal.AllocHGlobal(1000000 * sizeof(int));
            *buffer = 42;


            int size = 2147483647;
            while (true)
            {
                unchecked
                {
                    bufferOverflow("azertyuiopa");
                    int[] array = new int[size];
                    Console.WriteLine($"Allocated {size} integers");
                    size *= 2;
                }
            }
        }
    }
}