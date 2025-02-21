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
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;

        public List<DateTime> getFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            /*            <== Boucle FOR ==>      
            for (int i = 0; i < Flights.Count; i++)
                if (Flights[i].Destination == destination)
                    dates.Add(Flights[i].FlightDate);
            foreach (Flight f in Flights)
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);
            */

            dates = (from f in Flights
                    where f.Destination == destination
                    select f.FlightDate).ToList();

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

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.Plane == plane
                      select new { f.FlightDate, f.Destination };

            foreach (var f in req)
                Console.WriteLine(f);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(f.FlightDate, startDate) >= 0
                      && (f.FlightDate - startDate).TotalDays < 8
                      select f;

            return req.Count();
        }

        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination == destination
                      select f.EstimatedDuration;

            return req.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;

            return req;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {
            var req = from t in f.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t;

            return req.Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestionationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach (Flight f in g)
                    Console.WriteLine(f.FlightDate);
            }

            return req;
        }
    }
}
