// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Plane plane1 = new Plane();
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2025,01,31);
plane1.PlaneType = PlaneType.Boeing;
//Object Initialisar
Plane plane2 = new Plane { Capacity = 100, PlaneType = PlaneType.Airbus, ManufactureDate = DateTime.Now };
Console.WriteLine(plane2);

Console.WriteLine("************* PassengerType **********");
Passenger p1 = new Passenger 
{ 
    FirstName = "HaFedh",
    LastName = "Jendoubi",
    BirthDate = new DateTime(2002,11,22),
    TelNumber = "+21652896806",
    EmailAddress = "hafedh.jendoubi@esprit.tn"
};
Staff s1 = new Staff();
Traveller t1 = new Traveller();
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();

Console.WriteLine("************* CheckProfile **********");
Console.WriteLine(p1.CheckProfile("Hafedh", "Jendoubi"));
Console.WriteLine(p1.CheckProfile("Hafedh", "Jendoubi", "nour@esprit.tn"));

Console.WriteLine("************* GetFlightDates **********");
FlightMethods flightMethods = new FlightMethods();
flightMethods.Flights = TestData.listFlights;
foreach(DateTime d in flightMethods.getFlightDates("Paris"))
    Console.WriteLine(d);

Console.WriteLine("************* GetFlights **********");
flightMethods.GetFlights("Destination", "Madrid");
flightMethods.GetFlights("EstimatedDuration", "105");

Console.WriteLine("************* ShowFlightDetails **********");
flightMethods.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("************* ProgrammedFlightNumber **********");
Console.WriteLine(flightMethods.ProgrammedFlightNumber(new DateTime(2021, 12, 31)));

Console.WriteLine("************* DurationAverage **********");
Console.WriteLine(flightMethods.DurationAverage("Paris"));

Console.WriteLine("************* OrderedDurationFlights **********");
foreach (Flight f in flightMethods.OrderedDurationFlights())
    Console.WriteLine(f.Destination + " " + f.EstimatedDuration);

/*
Console.WriteLine("************* SeniorTravellers **********");
foreach (Traveller t in flightMethods.SeniorTravellers(TestData.flight1))
    Console.WriteLine(t.FirstName + " " + t.BirthDate);
*/

Console.WriteLine("************* DestionationGroupedFlights **********");
flightMethods.DestionationGroupedFlights();

Console.WriteLine("************* UpperFullName **********");
p1.UpperFullName();