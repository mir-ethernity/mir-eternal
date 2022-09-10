using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mir3DCrypto
{
    public class CryptoStream : Stream
    {
        public readonly Stream BaseStream;
        public bool Encrypted { get; }
        public override bool CanRead => BaseStream.CanRead;
        public override bool CanSeek => BaseStream.CanSeek;
        public override bool CanWrite => false;
        public override long Length => BaseStream.Length;
        public override long Position { get => BaseStream.Position; set => BaseStream.Position = value; }

        public CryptoStream(Stream stream, bool encrypted)
        {
            BaseStream = stream;
            Encrypted = encrypted;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var length = BaseStream.Read(buffer, offset, count);

            if (Encrypted)
                Crypto.Decrypt(buffer, offset, length);
            else
                Crypto.Encrypt(buffer, offset, length);

            return length;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
