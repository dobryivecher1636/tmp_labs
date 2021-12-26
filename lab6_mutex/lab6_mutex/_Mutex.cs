using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace lab6_mutex
{
    class _Mutex
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitialOwner,
   string lpName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReleaseMutex(IntPtr hMutex);

        public IntPtr handle; //дескриптор мьютекса

        const UInt32 INFINITE = 0xFFFFFFFF; //аргументы функции WaitForSingleObject
        const UInt32 WAIT_OBJECT_0 = 0x00000080;

        public _Mutex()
        {
            handle = CreateMutex(IntPtr.Zero, false, "nameofmutex");
        }

        public bool Wait() //функция Wait
        {
            return WaitForSingleObject(handle, INFINITE) == WAIT_OBJECT_0;
        }

        public bool Release() //функция Release
        {
            return ReleaseMutex(handle);
        }
    }
}
