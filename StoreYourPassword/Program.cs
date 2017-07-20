using System;

namespace StoreYourPassword
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StorePass sp = new StorePass();
            RetrievePass rp = new RetrievePass();
            StoreMasterPass smp = new StoreMasterPass();
            ReadPassword r = new ReadPassword();
            Logger logger = new Logger();

            var masterPassExists = rp.checkMasterPassExistance();
            if (masterPassExists != true)
            {
                Console.WriteLine("\nYou have not setup your master password yet.\n\nPlease enter your master password:");
                var masterPass = r.ReadPass();
                smp.storePassowrd(masterPass);
                Console.WriteLine("\n");
                logger.log("Master Password has been setup successfully.");
            }

            Console.WriteLine("Store Or Retrieve Password? Type S or R.");
            var userOption = Console.ReadLine().ToLower();

            Loop:
            switch (userOption)
            {
                case "s":
                    sp.storePassowrdMain();
                    break;

                case "r":
                    bool spam = rp.retrievePassMain();
                    if (spam != true)
                    {                        
                           return;
                    }
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nYou selected a wrong option.");                    
                    Console.ReadKey();
                    return;                    
            }
            Console.WriteLine("\nStore Or Retrieve more password? Type S or R.");
            userOption = Console.ReadLine().ToLower();
            goto Loop;            
        }
    }
}
