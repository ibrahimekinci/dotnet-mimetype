using MimeType.FileSignatureChecker;
using MimeType.FileSignatureChecker.Audio;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class AudioFileSignatures
    {
        // Flac matches a Free Lossless Audio Codec file.
        public static FileSignature Flac = new FileSignature(new PrefixFileSignatureChecker("\x66\x4C\x61\x43\x00\x00\x00\x22"));

        // Midi matches a Musical Instrument Digital Interface file.
        public static FileSignature Midi = new FileSignature(new PrefixFileSignatureChecker("\x4D\x54\x68\x64"));

        // Ape matches a Monkey's Audio file.
        public static FileSignature Ape = new FileSignature(new PrefixFileSignatureChecker("\x4D\x41\x43\x20\x96\x0F\x00\x00\x34\x00\x00\x00\x18\x00\x00\x00\x90\xE3"));

        // MusePack matches a Musepack file.
        public static FileSignature MusePack = new FileSignature(new PrefixFileSignatureChecker("MPCK"));

        // Au matches a Sun Microsystems au file.
        public static FileSignature Au = new FileSignature(new PrefixFileSignatureChecker("\x2E\x73\x6E\x64"));

        // Amr matches an Adaptive Multi-Rate file.
        public static FileSignature Amr = new FileSignature(new PrefixFileSignatureChecker("\x23\x21\x41\x4D\x52"));

        // Voc matches a Creative Voice file.
        public static FileSignature Voc = new FileSignature(new PrefixFileSignatureChecker("Creative Voice File"));

        // M3u matches a Playlist file.
        public static FileSignature M3u = new FileSignature(new PrefixFileSignatureChecker("#EXTM3U"));

        // AAC matches an Advanced Audio Coding file.
        public static FileSignature AAC = new FileSignature(new PrefixFileSignatureChecker(new byte[] { 0xFF, 0xF1 }, new byte[] { 0xFF, 0xF9 }));

        // Mp3 matches an mp3 file.
        public static FileSignature Mp3 = new FileSignature(new PrefixFileSignatureChecker(3, "ID3"));

        // Wav matches a Waveform Audio File Format file.
        public static FileSignature Wav = new FileSignature(new WavFileSignatureChecker());

        // Aiff matches Audio Interchange File Format file.
        public static FileSignature Aiff = new FileSignature(new AiffFileSignatureChecker());

        // Qcp matches a Qualcomm Pure Voice file.
        public static FileSignature Qcp = new FileSignature(new QcpFileSignatureChecker());
    }
}
