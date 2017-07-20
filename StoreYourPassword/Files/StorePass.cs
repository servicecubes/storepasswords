using System;
using System.IO;

namespace StoreYourPassword
{
    public class StorePass
    {
        WriteToFile write = new WriteToFile();
        RetrievePass rp = new RetrievePass();

        public void storePassowrdMain()
        {
            Console.Clear();
            Console.WriteLine("\nLet's store your password.");
            Console.WriteLine("\nWebsite?");
            var webSiteName = Console.ReadLine().ToLower();
            Console.WriteLine("\nId?");
            var id = Console.ReadLine();
            Console.WriteLine("\nPassword?");
            var pass = Console.ReadLine();
            var masterPass = rp.retrieveMasterPass();
            write.writePassOnCredentialFile(webSiteName, id, pass, masterPass);
        }        
    }  
}

