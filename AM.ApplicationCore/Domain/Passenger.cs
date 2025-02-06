using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
