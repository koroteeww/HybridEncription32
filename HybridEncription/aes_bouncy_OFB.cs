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
        

        internal static byte[] encrypt(string plaintext, byte[] bytesSessionkey)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] iv = new byte[128]; 

            AesEngine engine = new AesEngine();
            OfbBlockCipher blockCipher = new OfbBlockCipher(engine, 128); //OFB
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(blockCipher); //Default scheme is PKCS5/PKCS7
            KeyParameter keyParam = new KeyParameter(bytesSessionkey);
            ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv, 0, 128);

            // Encrypt
            cipher.Init(true, keyParamWithIV);
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, outputBytes, 0);
            cipher.DoFinal(outputBytes, length); //Do the final block

            return outputBytes;
        }
        static PaddedBufferedBlockCipher mcipher;
        static void init(byte[] bytesSessionkey)
        {
            byte[] iv = new byte[128];

            AesEngine engine = new AesEngine();
            OfbBlockCipher blockCipher = new OfbBlockCipher(engine, 128); //OFB
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(blockCipher); //Default scheme is PKCS5/PKCS7
            KeyParameter keyParam = new KeyParameter(bytesSessionkey);
            ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv, 0, 128);

        }
        internal static string decrypt(byte[] encrypteddata, byte[] bytesSessionkey)
        {
            byte[] iv = new byte[128];
            
            AesEngine engine = new AesEngine();
            OfbBlockCipher blockCipher = new OfbBlockCipher(engine, 128); //OFB
            PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(blockCipher); //Default scheme is PKCS5/PKCS7
            KeyParameter keyParam = new KeyParameter(bytesSessionkey);
            ParametersWithIV keyParamWithIV = new ParametersWithIV(keyParam, iv, 0, 128);
            byte[] outputBytes = encrypteddata;
            //Decrypt            
            cipher.Init(false, keyParamWithIV);
            byte[] comparisonBytes = new byte[cipher.GetOutputSize(outputBytes.Length)];
            int length = cipher.ProcessBytes(outputBytes, comparisonBytes, 0);
            cipher.DoFinal(comparisonBytes, length); //Do the final block

            

            return Encoding.UTF8.GetString(comparisonBytes);
        }
    }
}
