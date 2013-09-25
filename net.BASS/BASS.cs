using System;
using System.Runtime.InteropServices;

namespace net.BASS
{
    public class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_Init(int device, uint freq, uint flags, IntPtr win, IntPtr clsid);

        [DllImport(@"bass.dll", EntryPoint = "BASS_StreamCreateFile", CharSet = CharSet.Auto)]
        private static extern uint BASS_SCF([MarshalAs(UnmanagedType.Bool)]bool mem, [MarshalAs(UnmanagedType.LPStr)]string file, long offset, long lenght, uint flags);

        public static uint BASS_StreamCreateFile(string file, long offset, long lenght, uint flags)
        {
            return BASS_SCF(false, file, offset, lenght, flags);
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern bool BASS_ChannelPlay(uint handle, [MarshalAs(UnmanagedType.Bool)]bool restart);
    }
}
