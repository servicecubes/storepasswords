using System;
using System.IO;

namespace StoreYourPassword
{
    public class StoreMasterPass
    {
        TextEncryptionDecryption tcd = new TextEncryptionDecryption();

        public void storePassowrd(string password)
        {
            var encryptedPass = tcd.EncryptText(password, "applicationamibanaisi.passwordkaoredimuna");
                                    
            File.AppendAllText(@"donotdelete.txt", encryptedPass.ToString());            

            Console.WriteLine("\nYour Master Password has been setup.");
        }
    }  
}

