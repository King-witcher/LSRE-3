using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LSRE_3
{
    internal unsafe class Utils
    {
        public static T* malloc<T>(int count = 1) where T : unmanaged => (T*) Marshal.AllocHGlobal(count * sizeof(T));

        public static bool strcmp(char* first, char* second)
        {
            while (*first != 0 && *second != 0)
            {
                if (*first != *second)
                    return false;
                first++; second++;
            }
            return true;
        }
    }
}
