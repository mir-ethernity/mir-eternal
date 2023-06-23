using NAudio.Vorbis;
using NAudio.Wave;
using UELib.Core.Classes;

namespace Mir3DClientEditor.FormValueEditors
{
    public class PlaySongActive
    {
        public DataGridViewButtonCell Cell { get; set; }
        public USoundNodeWave Object { get; set; }
        public VorbisWaveReader Reader { get; set; }
        public WaveOutEvent WaveOutEvent { get; set; }

        public void Stop()
        {
            Cell.Value = "Play";
            Reader.Dispose();
            WaveOutEvent.Dispose();
        }
    }
}
