using System;
using System.Runtime.InteropServices;

namespace netBASS
{
    public partial class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern double BASS_ChannelBytes2Seconds(int handle, long pos);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ChannelFlags(int handle, int flags, int mask);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelGet3DAttributes(int handle, ref IntPtr mode, ref IntPtr min,
                ref IntPtr max, ref IntPtr iangle, ref IntPtr oangle, ref IntPtr outvol);  // Fix ME!

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern bool BASS_ChannelPlay(int handle, [MarshalAs(UnmanagedType.Bool)]bool restart);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern BASSActive BASS_ChannelIsActive(int handle);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_ChannelLock(int handle, [MarshalAs(UnmanagedType.Bool)]bool channelLock);

    }
}
