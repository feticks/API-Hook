using System;
using System.Runtime.InteropServices;

namespace APIHook {
    class Hook {
        IntPtr addr;
        uint old;
        byte[] src = new byte[5];
        byte[] dst = new byte[5];

        public Hook(IntPtr source, IntPtr destination) {
            WinAPI.VirtualProtect(source, 5, 0x40, out old);
            Marshal.Copy(source, src, 0, 5);
            dst[0] = 0xE9;
            var dx = BitConverter.GetBytes((int)destination - (int)source - 5);
            Array.Copy(dx, 0, dst, 1, 4);
            addr = source;
        }

        public void Enable() => Marshal.Copy(dst, 0, addr, 5);
        public void Disable() => Marshal.Copy(src, 0, addr, 5);
    }
}