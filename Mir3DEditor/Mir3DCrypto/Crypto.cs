namespace Mir3DCrypto
{
    public static class Crypto
    {

        public static byte[] Decrypt(byte[] buffer)
        {
            byte[] output = new byte[buffer.Length];

            for (var i = 0; i < buffer.Length; i++)
                output[i] = Constants.DecodeMapTable[buffer[i]];

            return output;
        }

        public static void Decrypt(byte[] buffer, int offset, int length)
        {
            for (var i = offset; i < length; i++)
                buffer[i] = Constants.DecodeMapTable[buffer[i]];
        }

        public static byte[] Encrypt(byte[] buffer)
        {
            byte[] output = new byte[buffer.Length];

            for (var i = 0; i < buffer.Length; i++)
                output[i] = Constants.EncodeMapTable[buffer[i]];

            return output;
        }

        public static void Encrypt(byte[] buffer, int offset, int length)
        {
            for (var i = offset; i < length; i++)
                buffer[i] = Constants.EncodeMapTable[buffer[i]];
        }
    }
}