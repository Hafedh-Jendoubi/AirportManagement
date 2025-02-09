using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> getFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            /*            <== Boucle FOR ==>      
            for (int i = 0; i < Flights.Count; i++)
                if (Flights[i].Destination == destination)
                    dates.Add(Flights[i].FlightDate);
            */
            foreach (Flight f in Flights)
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);

            return dates;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                        if(f.Destination == filterValue)
                            Console.WriteLine(f);
                    break;

                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure == filterValue)
                            Console.WriteLine(f);
                    break;

                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration == Int32.Parse(filterValue))
                            Console.WriteLine(f);
                    break;

                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    break;

                default:
                    Console.WriteLine("Vérifier le nom de la propriété");
                    break;
            }
        }
    }
}
