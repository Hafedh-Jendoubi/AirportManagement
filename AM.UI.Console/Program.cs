// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");
Plane plane1 = new Plane();
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2025,01,31);
plane1.PlaneType = PlaneType.Boeing;

//Object Initialisar
Plane plane2 = new Plane { Capacity = 100, PlaneType = PlaneType.Airbus, ManufactureDate = DateTime.Now };

Console.WriteLine(plane2);
Console.WriteLine("************* PassengerType **********");
Passenger p1 = new Passenger();
Staff s1 = new Staff();
Traveller t1 = new Traveller();
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();

//Question 10