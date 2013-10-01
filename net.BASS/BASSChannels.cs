using System;
using System.Runtime.InteropServices;

namespace netBASS
{
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public class BASS_3DVECTOR
    {
        public float x;
        public float y;
        public float z;
        public BASS_3DVECTOR(){}
        public BASS_3DVECTOR(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void SetValue(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Z: {2}", x, y, z);
        }
    }

    public partial class BASS
    {
        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern double BASS_ChannelBytes2Seconds(int handle, long pos);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ChannelFlags(int handle, int flags, int mask);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelGet3DAttributes(int handle, ref IntPtr mode, ref IntPtr min,
                ref IntPtr max, ref IntPtr iangle, ref IntPtr oangle, ref IntPtr outvol);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelGet3DPosition(int handle, IntPtr pos, IntPtr orient, IntPtr vel);

        public static bool BASS_ChannelGet3DPosition(int handle, BASS_3DVECTOR pos, BASS_3DVECTOR orient, BASS_3DVECTOR vel)
        {
            IntPtr[] ptr = new IntPtr[3];
            BASS_3DVECTOR[] args = new BASS_3DVECTOR[4];
            bool result;

            args[0] = pos;
            args[1] = orient;
            args[2] = vel;

            for (int i = 0; i < ptr.Length; i++)
            {
                if (args[i] != null)
                {
                    ptr[i] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BASS_3DVECTOR)));
                    Marshal.StructureToPtr(args[i], ptr[i], false);
                }
                else ptr[i] = IntPtr.Zero;
            }

            result = BASS_ChannelGet3DPosition(handle, ptr[0], ptr[1], ptr[2]);
            for (int i = 0; i < ptr.Length; i++)
            {
                if (ptr[i] != IntPtr.Zero)
                {
                    args[3] = (BASS_3DVECTOR)Marshal.PtrToStructure(ptr[i], typeof(BASS_3DVECTOR));
                    args[i].SetValue(args[3].x, args[3].y, args[3].z);
                    Marshal.FreeHGlobal(ptr[i]);
                }
            }
            return result;
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelSet3DPosition(int handle, IntPtr pos, IntPtr orient, IntPtr vel);

        public static bool BASS_ChannelSet3DPosition(int handle, BASS_3DVECTOR pos, BASS_3DVECTOR orient, BASS_3DVECTOR vel)
        {
            IntPtr[] ptr = new IntPtr[3];
            object[] args = new object[3];
            bool result;

            args[0] = pos;
            args[1] = orient;
            args[2] = vel;

            for (int i = 0; i < ptr.Length; i++)
            {
                if (args[i] != null)
                {
                    ptr[i] = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BASS_3DVECTOR)));
                    Marshal.StructureToPtr(args[i], ptr[i], false);
                }
                else  ptr[i] = IntPtr.Zero;
            }

            result = BASS_ChannelSet3DPosition(handle, ptr[0], ptr[1], ptr[2]);
            foreach (var p in ptr)
            {
                if (p != IntPtr.Zero) Marshal.FreeHGlobal(p);
            }
            return result;
        }

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern bool BASS_ChannelPlay(int handle, [MarshalAs(UnmanagedType.Bool)]bool restart);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern BASSActive BASS_ChannelIsActive(int handle);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_ChannelLock(int handle, [MarshalAs(UnmanagedType.Bool)]bool channelLock);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ChannelGetData(int handle, float[] buffer, BASSLenght lenght);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ChannelGetDevice(int handle);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern long BASS_ChannelGetLength(int handle, BASSPos mode);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern int BASS_ChannelGetLevel(int handle);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        public static extern long BASS_ChannelGetPosition(int handle, BASSPos mode);

    }
}
