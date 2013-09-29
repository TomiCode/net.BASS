using System;
using System.Runtime.InteropServices;

namespace netBASS
{

    public struct BASS_3DVECTOR
    {
        public float x;
        public float y;
        public float z;

        public BASS_3DVECTOR(float x, float y, float z)
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
                ref IntPtr max, ref IntPtr iangle, ref IntPtr oangle, ref IntPtr outvol);  // Fix ME!

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASS_ChannelGet3DPosition(int handle, BASS_3DVECTOR pos, BASS_3DVECTOR orient, BASS_3DVECTOR vel);

        [DllImport(@"bass.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BASS_ChannelSet3DPosition(int handle, IntPtr pos, IntPtr orient, IntPtr vel);

        public static bool BASS_ChannelSet3DPosition(int handle, BASS_3DVECTOR? pos, BASS_3DVECTOR? orient, BASS_3DVECTOR? vel)
        {
            IntPtr[] pointers = new IntPtr[3];
            int size;

            for (int i = 0; i < pointers.Length; i++)
			{
			    if(i == 0 && pos != null){
                    size = Marshal.SizeOf(typeof(BASS_3DVECTOR));
                    pointers[i] = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(pos, pointers[i], false);
                }
                else if(i == 1 && orient != null){
                    size = Marshal.SizeOf(typeof(BASS_3DVECTOR));
                    pointers[i] = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(orient, pointers[i], false);
                }
                else if(i == 2 && vel != null){
                    size = Marshal.SizeOf(typeof(BASS_3DVECTOR));
                    pointers[i] = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(vel, pointers[i], false);
                }
                else{
                    pointers[i] = IntPtr.Zero;
                }
			}

            bool result =  BASS_ChannelSet3DPosition(handle, pointers[0], pointers[1], pointers[2]);

            for (int i = 0; i < pointers.Length; i++)
            {
                if(pointers[i] != IntPtr.Zero)
                    Marshal.FreeHGlobal(pointers[i]);
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

    }
}
