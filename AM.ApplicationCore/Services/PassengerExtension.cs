using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p)
        {
            string FirstName = p.FirstName[0].ToString().ToUpper() + p.FirstName.Substring(1).ToLower();
            string LastName = p.LastName[0].ToString().ToUpper() + p.LastName.Substring(1).ToLower();
            Console.WriteLine(FirstName + " " + LastName);
        }
    }
}
