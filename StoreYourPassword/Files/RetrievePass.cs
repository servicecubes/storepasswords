using System.IO;
using System;

namespace StoreYourPassword
{
    public class RetrievePass
    {
        //StorePass sp = new StorePass();
        TextEncryptionDecryption tcd = new TextEncryptionDecryption();
        ReadPassword r = new ReadPassword();
        Logger logger = new Logger();

        public bool checkMasterPassExistance()
        {
            if (File.Exists(@"donotdelete.txt"))
            {
                using (StreamReader sr = new StreamReader(@"donotdelete.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        var line = sr.ReadLine();
                        if (line.Length > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public string retrieveMasterPass()
        {
            var line = " ";
            using (StreamReader sr = new StreamReader(@"donotdelete.txt"))
            {
                //while (sr.Peek() >= 0)
                //{
                line = sr.ReadLine();
                //}
            }
            var value = tcd.DecryptText(line, "applicationamibanaisi.passwordkaoredimuna");
            return value;
        }

        public bool retrievePassMain()
        {
            logger.log("Someone selected option to retrieve password.");
            Console.Clear();
            Console.WriteLine("Prove you are you ;) Password?");
            var masterPass = retrieveMasterPass();
            var masterPass1 = r.ReadPass();
            if (masterPass != masterPass1)
            {
                Console.Clear();
                Console.WriteLine("Spammer detected!");
                logger.log("Someone tried to retrieve passwords with wrong Master Password = '" + masterPass1 + "'");
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ok. So you are really you.\n\nWebsite to retrive pass?\n");
                var webSiteToRetrieve = Console.ReadLine();
                retrievePass(webSiteToRetrieve);
                logger.log("Someone searched for website: '" + webSiteToRetrieve + "'.");
                return true;
            }
        }

        public void retrievePass(string webSiteName)
        {
            Console.WriteLine("\n");
            var count = 0;
            var masterPass = retrieveMasterPass();

            using (StreamReader sr = new StreamReader(@"credentials\Cred.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    if (webSiteName.ToLower() == line.Split(',')[0].ToLower())
                    {
                        count++;
                        var text = line.Split(',')[2];

                        Console.WriteLine("Id:\t" + line.Split(',')[1] + "\t\t\tPass:\t" + tcd.DecryptText(text, masterPass));
                    }
                }
            }

            if (count == 1)
            {
                Console.WriteLine("\n" + count + " matched item found.\n\nEnd of search.");
            }
            else
            {
                Console.WriteLine("\n" + count + " matched items found.\n\nEnd of search.");
            }

        }
    }
}
