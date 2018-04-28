using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using Org.BouncyCastle;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace HybridEncription
{
    public partial class Form1 : Form
    {
        bool useBouncyCastle = true;

        Alice alice = new Alice();
        Bob bob = new Bob();

        CipherMode aesMode = CipherMode.CBC;



        //standart rsa
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        RSAParameters priv_key;
        RSAParameters pub_key;

        //bouncycastle rsa
        TFRSAEncryption RSA_BOUNCY = new TFRSAEncryption();

        public Form1()
        {
            InitializeComponent();

            

            //make a new csp with a new keypair
            csp = new RSACryptoServiceProvider();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = useBouncyCastle;
            //standart rsa
            pub_key = csp.ExportParameters(false); // export public key
            priv_key = csp.ExportParameters(true); // export private key

            comboBoxMode.SelectedIndex = 0;
            setAesMode();

            updateBobKeys();
        }
        void updateBobKeys()
        {
            if (useBouncyCastle)
            {
                textBoxBobOpenKey.Text = bob.publicKey;
                textBoxBobPrivateKey.Text = bob.getprivateKey();
            }
            else
            {
                bob.bobOpenKey = csp.ToXmlString(false);
                bob.bobPrivateKey = csp.ToXmlString(true);
                textBoxBobOpenKey.Text = bob.bobOpenKey;//rsaParamString(pub_key);
                textBoxBobPrivateKey.Text = bob.bobPrivateKey;
            }
        }
        private void buttonGenKey_Click(object sender, EventArgs e)
        {
            //generate random 256-bit (32 bytes) key
            using (var random = new RNGCryptoServiceProvider())
            {
                var key = new byte[32];
                random.GetBytes(key);
                alice.sessionkey = Convert.ToBase64String(key);
                alice.BytesSessionkey = key;
            }
            //sessionkey = (Guid.NewGuid()).ToString();
            labelSessionKey.Text = alice.sessionkey;
        }

        private void buttonEncryptAes_Click(object sender, EventArgs e)
        {
            alice.plaintext = textBoxPlainTextAlice.Text;
            if (!string.IsNullOrEmpty(alice.plaintext) && alice.BytesSessionkey != null)
            {
                if (aesMode == CipherMode.OFB)
                {
                    //работает только в bouncyCastle
                    // Encrypt the string to an array of bytes. 
                    byte[] encrypted = AES_bouncy_OFB.encrypt(alice.plaintext, alice.BytesSessionkey);//AES.EncryptStringToBytes_Aes(alice.plaintext, alice.BytesSessionkey);

                    alice.encryptedMessage = Convert.ToBase64String(encrypted);
                    alice.encryptedMessageBytes = encrypted;
                    textBoxEncryptedMessageAlice.Text = alice.encryptedMessage;
                }
                else
                {

                    //byte[] bytesKey = Encoding.UTF8.GetBytes(sessionkey);
                    // Encrypt the string to an array of bytes. 
                    byte[] encrypted = AES.EncryptStringToBytes_Aes(alice.plaintext, alice.BytesSessionkey);

                    alice.encryptedMessage = Convert.ToBase64String(encrypted);
                    alice.encryptedMessageBytes = encrypted;
                    textBoxEncryptedMessageAlice.Text = alice.encryptedMessage;
                }
            }
            else
            {
                MessageBox.Show("plaintext or session key empty");
            }
            
        }

        private void buttonEncryptKeyRSA_Click(object sender, EventArgs e)
        {
            if (alice.BytesSessionkey != null)
            {
                if (!useBouncyCastle)
                {
                    byte[] data = alice.BytesSessionkey;

                    csp.ImportParameters(pub_key);//using public key
                    var encData = csp.Encrypt(data, false); // encrypt with PKCS#1_V1.5 Padding
                    alice.encryptedSessionKeyBytes = encData;
                    alice.encryptedSessionKey = Convert.ToBase64String(alice.encryptedSessionKeyBytes);
                    labelEncKey.Text = alice.encryptedSessionKey;
                }
                else
                {
                    byte[] data = alice.BytesSessionkey;
                    var encryptedWithPublic = RSA_BOUNCY.RsaEncryptWithPublicBytes(data, bob.publicKey);
                    alice.encryptedSessionKeyBytes = encryptedWithPublic;
                    alice.encryptedSessionKey = Convert.ToBase64String(alice.encryptedSessionKeyBytes);
                    labelEncKey.Text = alice.encryptedSessionKey;

                    ////bouncy RSA EXAMPLE
                    //// Set up 
                    //var input = "Perceived determine departure explained no forfeited";
                    //// Encrypt it
                    //var encryptedWithPublic = RSA_BOUNCY.RsaEncryptWithPublic(input, publicKey);
                    //var encryptedWithPrivate = RSA_BOUNCY.RsaEncryptWithPrivate(input, privateKey);
                    //// Decrypt
                    //var output1 = RSA_BOUNCY.RsaDecryptWithPrivate(encryptedWithPublic, privateKey);
                    //var output2 = RSA_BOUNCY.RsaDecryptWithPublic(encryptedWithPrivate, publicKey);
                }
            }
            else
            {
                MessageBox.Show("BytesSessionkey null");
            }
            

            //string priv = Convert.ToBase64String(Encoding.UTF8.GetBytes(bobPrivateKey));
            //string priv = Convert.ToBase64String(Encoding.UTF8.GetBytes("OLOLO"));
            //string pub = Convert.ToBase64String(Encoding.UTF8.GetBytes("TROLOLO"));
            //RsaPrivateCrtKeyParameters privateKeyParameters = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(priv));
            //AsymmetricKeyParameter publicKeyInfoParameters = PublicKeyFactory.CreateKey(Convert.FromBase64String(pub));
            //byte[] clearData = BytesSessionkey;
            //string algorithm = "RSA/ECB/PKCS1Padding";

            //var cipherOne = CipherUtilities.GetCipher(algorithm);
            //cipherOne.Init(true, privateKeyParameters);
            //byte[] signedData = cipherOne.DoFinal(clearData);

            //var clientTwo = CipherUtilities.GetCipher(algorithm);
            //clientTwo.Init(false, publicKeyInfoParameters);
            //var clearDataTwo = clientTwo.DoFinal(signedData);

            //System.Diagnostics.Debug.Assert(Convert.ToBase64String(clearData) == Convert.ToBase64String(clearDataTwo));


            MessageBox.Show("Ok");

        }

        private void buttonSendKeyMessage_Click(object sender, EventArgs e)
        {
            //все нужные переменные уже есть
            if (alice.encryptedSessionKeyBytes != null && alice.encryptedMessageBytes != null)
            {
                bob.getMessageFromAlice(alice.encryptedMessageBytes, alice.encryptedSessionKeyBytes);
                MessageBox.Show("Ok");
            }
            else
                MessageBox.Show("encryptedSessionKeyBytes or encryptedMessageBytes null");

        }

        private void buttonDecryptSeessionKey_Click(object sender, EventArgs e)
        {
            //not working...
            //var dd = csp.Decrypt(encryptedSessionKeyBytes,false);
            //var dkey = Convert.ToBase64String(dd);
            if (!useBouncyCastle)
            {
                var decData = bob.decryptKeyStandart(priv_key);
                

                labelDecryptedKey.Text = Convert.ToBase64String(decData);
            }
            else
            {
                //using BouncyCastle
                var decData = bob.decryptKeyBouncy();

                labelDecryptedKey.Text = Convert.ToBase64String(decData);
            }


        }


        //private string rsaParamString(RSAParameters key)
        //{
        //    string d = key.D == null ? "" : Convert.ToBase64String(key.D);
        //    string m = key.Modulus == null ? "" : Convert.ToBase64String(key.Modulus);
        //    string p = key.P == null ? "" : Convert.ToBase64String(key.P);

        //    string dp = key.P == null ? "" : Convert.ToBase64String(key.DP);
        //    string dq = key.P == null ? "" : Convert.ToBase64String(key.DQ);
        //    string exp = key.P == null ? "" : Convert.ToBase64String(key.Exponent);
        //    return  d+ m + p+dp+dq+exp;
        //}
        private void buttonDecryptMessageAes_Click(object sender, EventArgs e)
        {

            var res = bob.decryptMessage(aesMode);
            textBoxDecryptedMessage.Text = res;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            useBouncyCastle = checkBox1.Checked;
            updateBobKeys();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = comboBoxMode.Items[comboBoxMode.SelectedIndex].ToString();
            if (mode == "CBC")
            {
                //cipher block chaining
                aesMode = CipherMode.CBC;
            }
            if (mode == "OFB")
            {
                //output feedback
                aesMode = CipherMode.OFB;
            }
            if (mode == "CFB")
            {
                //cipher feedback
                aesMode = CipherMode.CFB;
            }
            setAesMode();
        }
        void setAesMode()
        {
            AES.cipherMode = aesMode;
            var text = "2.Encrypt message AES (mode " + aesMode + ")";
            buttonEncryptAes.Text = text;
            var text2= "6. Decrypt message AES (mode " + aesMode + ")";
            buttonDecryptMessageAes.Text = text2;
        }
    }
}
