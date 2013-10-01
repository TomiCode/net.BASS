using System;
using System.Runtime.InteropServices;

namespace netBASS
{
    public enum BASSChannelAttrib
    {
        BASS_ATTRIB_FREQ = 1,
        BASS_ATTRIB_VOL	= 2,
        BASS_ATTRIB_PAN	= 3,
        BASS_ATTRIB_EAXMIX = 4,
        BASS_ATTRIB_NOBUFFER = 5,
        BASS_ATTRIB_CPU = 7,
        BASS_ATTRIB_SRC = 8,
        BASS_ATTRIB_MUSIC_AMPLIFY = 0x100,
        BASS_ATTRIB_MUSIC_PANSEP = 0x101,
        BASS_ATTRIB_MUSIC_PSCALER = 0x102,
        BASS_ATTRIB_MUSIC_BPM = 0x103,
        BASS_ATTRIB_MUSIC_SPEED = 0x104,
        BASS_ATTRIB_MUSIC_VOL_GLOBAL = 0x105,
        BASS_ATTRIB_MUSIC_VOL_CHAN = 0x200, // + channel #
        BASS_ATTRIB_MUSIC_VOL_INST = 0x300 // + instrument #
    }

    public partial class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelGetAttribute(int handle, BASSChannelAttrib attrib, IntPtr value);

        public static bool BASS_ChannelGetAttribute(int handle, BASSChannelAttrib attrib, out float value)
        {

            IntPtr val = Marshal.AllocHGlobal(sizeof(float));
            bool result;
            float[] _val = new float[1];

            result =  BASS_ChannelGetAttribute(handle, attrib, val);
            Marshal.Copy(val, _val, 0, 1);
            value = _val[0];

            Marshal.FreeHGlobal(val);
            return result;
        }
    }
}
