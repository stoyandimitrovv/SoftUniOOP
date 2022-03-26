using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Engine
    {
        public Engine()
        {
            this.smartphone = new Smartphone();
            this.phoneNumbers = new List<string>();
            this.urls = new List<string>();
        }

        private Smartphone smartphone;

        private IList<string> phoneNumbers;

        private IList<string> urls;

        public void Run()
        {
            this.phoneNumbers = Console.ReadLine().Split().ToList();
            this.urls = Console.ReadLine().Split().ToList();

            callPhoneNumber();
            BrowseUrls();
        }

        private void BrowseUrls()
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void callPhoneNumber()
        {
            foreach (var phoneNumber in this.phoneNumbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(phoneNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);        
                }
            }
        }
    }
}
