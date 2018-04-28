using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncription
{
    internal class Bob
    {
        //standart rsa
        internal string bobOpenKey = "";
        internal string bobPrivateKey = "";

        //BouncyCastle RSA
        internal byte[] BouncyEncryptedSessionKeyBytes;
        internal string BouncyEncryptedSessionKey = "";
        internal byte[] BouncyDecryptedSessionKeyBytes;
        internal string BouncyDecryptedSessionKey = "";
        /// <summary>
        /// rsa public key
        /// </summary>
        internal string publicKey = "-----BEGIN PUBLIC KEY-----\r\nMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCqGKukO1De7zhZj6+H0qtjTkVxwTCpvKe4eCZ0FPqri0cb2JZfXJ/DgYSF6vUpwmJG8wVQZKjeGcjDOL5UlsuusFncCzWBQ7RKNUSesmQRMSGkVb1/3j+skZ6UtW+5u09lHNsj6tQ51s1SPrCBkedbNf0Tp0GbMJDyR4e9T04ZZwIDAQAB\r\n-----END PUBLIC KEY-----";
        /// <summary>
        /// rsa private key
        /// </summary>
        private string privateKey = "-----BEGIN RSA PRIVATE KEY-----\r\nMIICXAIBAAKBgQCqGKukO1De7zhZj6+H0qtjTkVxwTCpvKe4eCZ0FPqri0cb2JZfXJ/DgYSF6vUpwmJG8wVQZKjeGcjDOL5UlsuusFncCzWBQ7RKNUSesmQRMSGkVb1/3j+skZ6UtW+5u09lHNsj6tQ51s1SPrCBkedbNf0Tp0GbMJDyR4e9T04ZZwIDAQABAoGAFijko56+qGyN8M0RVyaRAXz++xTqHBLh3tx4VgMtrQ+WEgCjhoTwo23KMBAuJGSYnRmoBZM3lMfTKevIkAidPExvYCdm5dYq3XToLkkLv5L2pIIVOFMDG+KESnAFV7l2c+cnzRMW0+b6f8mR1CJzZuxVLL6Q02fvLi55/mbSYxECQQDeAw6fiIQXGukBI4eMZZt4nscy2o12KyYner3VpoeE+Np2q+Z3pvAMd/aNzQ/W9WaI+NRfcxUJrmfPwIGm63ilAkEAxCL5HQb2bQr4ByorcMWm/hEP2MZzROV73yF41hPsRC9m66KrheO9HPTJuo3/9s5p+sqGxOlFL0NDt4SkosjgGwJAFklyR1uZ/wPJjj611cdBcztlPdqoxssQGnh85BzCj/u3WqBpE2vjvyyvyI5kX6zk7S0ljKtt2jny2+00VsBerQJBAJGC1Mg5Oydo5NwD6BiROrPxGo2bpTbu/fhrT8ebHkTz2eplU9VQQSQzY1oZMVX8i1m5WUTLPz2yLJIBQVdXqhMCQBGoiuSoSjafUhV7i1cEGpb88h5NBYZzWXGZ37sJ5QsW+sJyoNde3xH8vdXhzU7eT82D6X/scw9RZz+/6rCJ4p0=\r\n-----END RSA PRIVATE KEY-----";

        internal string getprivateKey()
        {
            var sha = SHA512.Create();

            return Convert.ToBase64String(sha.ComputeHash( Encoding.UTF8.GetBytes(privateKey)  ));
        }

        TFRSAEncryption RSA_BOUNCY = new TFRSAEncryption();

        internal string decryptedMessage = "";
        internal byte[] decryptedSessionKeyBytes;
        internal string decryptedSessionKey = "";

        internal byte[] encryptedMessageBytes;
        internal byte[] encryptedSessionKeyBytes;

        internal void getMessageFromAlice(byte[] message,byte[] sessionkey)
        {
            encryptedMessageBytes = message;
            encryptedSessionKeyBytes = sessionkey;
        }
        internal byte[] decryptKeyStandart(RSAParameters privkey)
        {
            //decrypt with own BigInteger based implementation
            var decBytes = MyRSAImpl.plainDecryptPriv(encryptedSessionKeyBytes, privkey);
            var decData = decBytes.SkipWhile(x => x != 0).Skip(1).ToArray();//strip PKCS#1_V1.5 padding
            decryptedSessionKeyBytes = decData;
            decryptedSessionKey = Convert.ToBase64String(decryptedSessionKeyBytes);
            return decData;
        }
        internal byte[] decryptKeyBouncy()
        {
            var output1 = RSA_BOUNCY.RsaDecryptWithPrivateBytes(encryptedSessionKeyBytes, privateKey);
            decryptedSessionKeyBytes = output1;
            decryptedSessionKey = Convert.ToBase64String(decryptedSessionKeyBytes);
            return output1;
        }
        internal string decryptMessage(CipherMode aesMode)
        {
            if (aesMode == CipherMode.OFB)
            {
                var res = AES_bouncy_OFB.decrypt(encryptedMessageBytes, decryptedSessionKeyBytes);
                decryptedMessage = res;
                return res;
            }
            else
            {
                var res = AES.DecryptStringFromBytes_Aes(encryptedMessageBytes, decryptedSessionKeyBytes);
                decryptedMessage = res;
                return res;
            }
        }
    }
}
