using MimeType.FileSignatureChecker;
using MimeType.Models;

namespace MimeType.FileSignatures
{
    internal class OggFileSignatures
    {
        /*
         NOTE:

         In May 2003, two Internet RFCs were published relating to the format.
         The Ogg bitstream was defined in RFC 3533 (which is classified as
         'informative') and its Internet content type (application/ogg) in RFC
         3534 (which is, as of 2006, a proposed standard protocol). In
         September 2008, RFC 3534 was obsoleted by RFC 5334, which added
         content types video/ogg, audio/ogg and filename extensions .ogx, .ogv,
         .oga, .spx.

         See:
         https://tools.ietf.org/html/rfc3533
         https://developer.mozilla.org/en-US/docs/Web/HTTP/Configuring_servers_for_Ogg_media#Serve_media_with_the_correct_MIME_type
         https://github.com/file/file/blob/master/magic/Magdir/vorbis
        */

        // Ogg matches an Ogg file.
        public static FileSignature Ogg = new FileSignature(new PrefixFileSignatureChecker("\x4F\x67\x67\x53\x00"));

        // Ogg matches an Ogg file.
        public static FileSignature OggAudio = new FileSignature(new OffsetFileSignatureChecker(28, 37, "\x7fFLAC", "\x01vorbis", "OpusHead", "Speex\x20\x20\x20"));

        // Ogg matches an Ogg file.
        public static FileSignature OggVideo = new FileSignature(new OffsetFileSignatureChecker(28, 37, "\x80theora", "fishead\x00", "\x01video\x00\x00\x00"));

    }
}
