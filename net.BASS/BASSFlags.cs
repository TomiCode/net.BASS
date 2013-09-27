using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace netBASS
{
    public enum BASSInit
    {
        BASS_DEVICE_8BITS = 1,		// 8 bit resolution, else 16 bit
        BASS_DEVICE_MONO = 2,		// mono, else stereo
        BASS_DEVICE_3D = 4,		// enable 3D functionality
        BASS_DEVICE_LATENCY = 0x100,	// calculate device latency (BASS_INFO struct)
        BASS_DEVICE_CPSPEAKERS = 0x400,	// detect speakers via Windows control panel
        BASS_DEVICE_SPEAKERS = 0x800,	// force enabling of speaker assignment
        BASS_DEVICE_NOSPEAKER = 0x1000,	// ignore speaker arrangement
        BASS_DEVICE_DMIX = 0x2000,	// use ALSA "dmix" plugin
        BASS_DEVICE_FREQ = 0x4000	// set device sample rate
    }

    public enum BASSFlag
    {
        BASS_DEFAULT            = 0,    // Default settings.
        BASS_SAMPLE_8BITS       = 1,	// 8 bit
        BASS_SAMPLE_MONO        = 2,	// mono
        BASS_SAMPLE_LOOP        = 4,	// looped
        BASS_SAMPLE_3D          = 8,	// 3D functionality
        BASS_SAMPLE_SOFTWARE    = 16,	// not using hardware mixing
        BASS_SAMPLE_MUTEMAX     = 32,	// mute at max distance (3D only)
        BASS_SAMPLE_VAM         = 64,	// DX7 voice allocation & management
        BASS_SAMPLE_FX          = 128,  // old implementation of DX8 effects
        BASS_SAMPLE_FLOAT       = 256,	// 32-bit floating-point
        BASS_SAMPLE_OVER_VOL    = 0x10000,	// override lowest volume
        BASS_SAMPLE_OVER_POS    = 0x20000,	// override longest playing
        BASS_SAMPLE_OVER_DIST   = 0x30000,   // override furthest from listener (3D only)

        BASS_STREAM_PRESCAN     = 0x20000, // enable pin-point seeking/length (MP3/MP2/MP1)
        BASS_MP3_SETPOS	        = BASS_STREAM_PRESCAN,
        BASS_STREAM_AUTOFREE    = 0x40000,	// automatically free the stream when it stop/ends
        BASS_STREAM_RESTRATE    = 0x80000,	// restrict the download rate of internet file streams
        BASS_STREAM_BLOCK       = 0x100000,// download/play internet file stream in small blocks
        BASS_STREAM_DECODE      = 0x200000, // don't play the stream, only decode (BASS_ChannelGetData)
        BASS_STREAM_STATUS      = 0x800000, // give server status info (HTTP/ICY tags) in DOWNLOADPROC

        BASS_MUSIC_FLOAT        = BASS_SAMPLE_FLOAT,
        BASS_MUSIC_MONO         = BASS_SAMPLE_MONO,
        BASS_MUSIC_LOOP         = BASS_SAMPLE_LOOP,
        BASS_MUSIC_3D           = BASS_SAMPLE_3D,
        BASS_MUSIC_FX           = BASS_SAMPLE_FX,
        BASS_MUSIC_AUTOFREE     = BASS_STREAM_AUTOFREE,
        BASS_MUSIC_DECODE       = BASS_STREAM_DECODE,
        BASS_MUSIC_PRESCAN      = BASS_STREAM_PRESCAN,	// calculate playback length
        BASS_MUSIC_CALCLEN      = BASS_MUSIC_PRESCAN,
        BASS_MUSIC_RAMP         = 0x200,	// normal ramping
        BASS_MUSIC_RAMPS        = 0x400,	// sensitive ramping
        BASS_MUSIC_SURROUND     = 0x800,	// surround sound
        BASS_MUSIC_SURROUND2    = 0x1000,	// surround sound (mode 2)
        BASS_MUSIC_FT2MOD       = 0x2000,	// play .MOD as FastTracker 2 does
        BASS_MUSIC_PT1MOD       = 0x4000,	// play .MOD as ProTracker 1 does
        BASS_MUSIC_NONINTER     = 0x10000,	// non-interpolated sample mixing
        BASS_MUSIC_SINCINTER    = 0x800000, // sinc interpolated sample mixing
        BASS_MUSIC_POSRESET     = 0x8000,	// stop all notes when moving position
        BASS_MUSIC_POSRESETEX   = 0x400000, // stop all notes and reset bmp/etc when moving position
        BASS_MUSIC_STOPBACK     = 0x80000,	// stop the music on a backwards jump effect
        BASS_MUSIC_NOSAMPLE     = 0x100000, // don't load the samples

        // Speaker assignment flags
        BASS_SPEAKER_FRONT      = 0x1000000,	// front speakers
        BASS_SPEAKER_REAR       = 0x2000000,	// rear/side speakers
        BASS_SPEAKER_CENLFE     = 0x3000000,	// center & LFE speakers (5.1)
        BASS_SPEAKER_REAR2      = 0x4000000,	// rear center speakers (7.1)
        BASS_SPEAKER_LEFT       = 0x10000000,	// modifier: left
        BASS_SPEAKER_RIGHT      = 0x20000000,	// modifier: right
        BASS_SPEAKER_FRONTLEFT  = BASS_SPEAKER_FRONT|BASS_SPEAKER_LEFT,
        BASS_SPEAKER_FRONTRIGHT = BASS_SPEAKER_FRONT|BASS_SPEAKER_RIGHT,
        BASS_SPEAKER_REARLEFT   = BASS_SPEAKER_REAR|BASS_SPEAKER_LEFT,
        BASS_SPEAKER_REARRIGHT  = BASS_SPEAKER_REAR|BASS_SPEAKER_RIGHT,
        BASS_SPEAKER_CENTER     = BASS_SPEAKER_CENLFE|BASS_SPEAKER_LEFT,
        BASS_SPEAKER_LFE        = BASS_SPEAKER_CENLFE|BASS_SPEAKER_RIGHT,
        BASS_SPEAKER_REAR2LEFT  = BASS_SPEAKER_REAR2|BASS_SPEAKER_LEFT,
        BASS_SPEAKER_REAR2RIGHT = BASS_SPEAKER_REAR2|BASS_SPEAKER_RIGHT,

        BASS_ASYNCFILE          = 0x40000000,
        BASS_UNICODE            = -2147483648
    };
}
