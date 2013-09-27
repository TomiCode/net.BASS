using System;
using System.Runtime.InteropServices;

namespace netBASS
{
    public class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_Init(int device, uint freq, BASSInit flags, IntPtr win, IntPtr clsid);

        [DllImport(@"bass.dll", EntryPoint = "BASS_StreamCreateFile", CharSet = CharSet.Auto)]
        private static extern uint BASS_SCF([MarshalAs(UnmanagedType.Bool)]bool mem, [MarshalAs(UnmanagedType.LPStr)]string file, long offset, long lenght, BASSFlag flags);

        public static uint BASS_StreamCreateFile(string file, long offset, long lenght, BASSFlag flags)
        {
            return BASS_SCF(false, file, offset, lenght, flags);
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern bool BASS_ChannelPlay(uint handle, [MarshalAs(UnmanagedType.Bool)]bool restart);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ErrorGetCode();

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_MusicFree(uint handle);

        [DllImport(@"bass.dll", EntryPoint = "BASS_MusicLoad", CharSet = CharSet.Auto)]
        private static extern uint BASS_ML([MarshalAs(UnmanagedType.Bool)]bool mem, IntPtr file,
            long offset, int lenght, BASSFlag flags, uint freq);

        public static uint BASS_MusicLoad(string file, long offset, int lenght, BASSFlag flags, uint freq)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(file);
            return BASS_ML(false, ptr, offset, lenght, flags, freq); 
        }

        public static uint BASS_MusicLoad(byte[] file, long offset, int lenght, BASSFlag flags, uint freq)
        {
            IntPtr ptr = Marshal.AllocHGlobal(file.Length);
            Marshal.Copy(file, 0, ptr, file.Length);

            return BASS_ML(true, ptr , offset, file.Length, flags, freq);
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

    }
}
