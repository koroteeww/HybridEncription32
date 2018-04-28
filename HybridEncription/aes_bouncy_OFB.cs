using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace HybridEncription
{
    internal static class AES_bouncy_OFB
    {
        static int bufsize = 128;

        internal static byte[] encrypt(string plaintext, byte[] bytesSessionkey)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] iv = new byte[bufsize];
            init(bytesSessionkey);
           
            // Encrypt
            mcipher.Init(true, mkeyParamWithIV);
            byte[] outputBytes = new byte[mcipher.GetOutputSize(inputBytes.Length)];
            int length = mcipher.ProcessBytes(inputBytes, outputBytes, 0);
            mcipher.DoFinal(outputBytes, length); //Do the final block

            return outputBytes;
        }
        private static PaddedBufferedBlockCipher mcipher;
        private static ParametersWithIV mkeyParamWithIV;
        private static void init(byte[] bytesSessionkey)
        {
            byte[] iv = new byte[128];

            AesEngine engine = new AesEngine();
            OfbBlockCipher blockCipher = new OfbBlockCipher(engine, bufsize); //OFB
            mcipher = new PaddedBufferedBlockCipher(blockCipher); //Default scheme is PKCS5/PKCS7
            KeyParameter keyParam = new KeyParameter(bytesSessionkey);
            mkeyParamWithIV = new ParametersWithIV(keyParam, iv, 0, bufsize);

        }
        internal static string decrypt(byte[] encrypteddata, byte[] bytesSessionkey)
        {
            byte[] iv = new byte[128];

            init(bytesSessionkey);

            byte[] outputBytes = encrypteddata;
            //Decrypt            
            mcipher.Init(false, mkeyParamWithIV);
            byte[] decryptedBytes = new byte[mcipher.GetOutputSize(outputBytes.Length)];
            int length = mcipher.ProcessBytes(outputBytes, decryptedBytes, 0);
            mcipher.DoFinal(decryptedBytes, length); //Do the final block

            

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
