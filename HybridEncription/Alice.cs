using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridEncription
{
    internal class Alice
    {
        internal string sessionkey = "";
        internal byte[] BytesSessionkey;
        internal string bobOpenKey = "";


        internal string plaintext = "";
        internal string encryptedMessage = "";
        internal byte[] encryptedMessageBytes;
        internal string encryptedSessionKey = "";
        internal byte[] encryptedSessionKeyBytes;

        
    }
}
