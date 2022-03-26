
using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {


        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExeptionMassages.InvalidNumberExeption);
            }

            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException(ExeptionMassages.InvalidUrlExeption);
            }

            return $"Browsing: {url}!";
        }    
    }
}
