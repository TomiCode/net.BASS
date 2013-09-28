using System;
using System.Runtime.InteropServices;

namespace netBASS
{
    public class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_Init(int device, int freq, BASSInit flags, IntPtr win, IntPtr clsid);

        public static bool BASS_Init(int device, int freq, BASSInit flags, IntPtr win)
        {
            return BASS_Init(device, freq, flags, win, IntPtr.Zero);
        }

        [DllImport(@"bass.dll", EntryPoint = "BASS_StreamCreateFile", CharSet = CharSet.Auto)]
        private static extern int BASS_SCF([MarshalAs(UnmanagedType.Bool)]bool mem, [MarshalAs(UnmanagedType.LPStr)]string file, long offset, long lenght, BASSFlag flags);

        public static int BASS_StreamCreateFile(string file, long offset, long lenght, BASSFlag flags)
        {
            return BASS_SCF(false, file, offset, lenght, flags);
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern bool BASS_ChannelPlay(int handle, [MarshalAs(UnmanagedType.Bool)]bool restart);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern BASSError BASS_ErrorGetCode();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_MusicFree(int handle);

        [DllImport(@"bass.dll", EntryPoint = "BASS_MusicLoad", CharSet = CharSet.Auto)]
        private static extern int BASS_ML([MarshalAs(UnmanagedType.Bool)]bool mem, IntPtr file, long offset, int lenght, BASSFlag flags, int freq);

        public static int BASS_MusicLoad(string file, long offset, int lenght, BASSFlag flags, int freq)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(file);
            int handle = BASS_ML(false, ptr, offset, lenght, flags, freq);
            Marshal.FreeHGlobal(ptr);

            return handle;
        }

        public static int BASS_MusicLoad(byte[] file, long offset, int lenght, BASSFlag flags, int freq)
        {
            IntPtr ptr = Marshal.AllocHGlobal(file.Length);
            Marshal.Copy(file, 0, ptr, file.Length);

            int handle = BASS_ML(true, ptr , offset, file.Length, flags, freq);
            Marshal.FreeHGlobal(ptr);

            return handle;
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_Free();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_SetDevice(uint device);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern uint BASS_GetDevice();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern float BASS_GetCPU();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_Start();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern BASSActive BASS_ChannelIsActive(int handle);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_ChannelLock(int handle, [MarshalAs(UnmanagedType.Bool)]bool channelLock);

    }
}
