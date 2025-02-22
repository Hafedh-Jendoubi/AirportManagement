using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
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

        //public Boolean CheckProfile(string first, string last)
        //{
        //    return (FirstName == first && LastName == last);
        //}

        //This function allows us to merge the two functions in one using the nullabale attribute
        public Boolean CheckProfile(string first, string last, string email=null)
        {
            if(email == null) 
                return (FirstName == first && LastName == last && EmailAddress == email);
            return (FirstName == first && LastName == last);
        }
    }
}
