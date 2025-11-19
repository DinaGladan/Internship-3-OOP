using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Classes
{
    internal class Flight
    {
        private string Id {  get; set; }
        public string Name { get; set; }
        public DateOnly DepartureDate { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public double Distance { get; set; }
        public TimeSpan TimeTravel { get; set; }

        public int StandardSeats { get; set; }
        public int BusinessSeats { get; set; }
        public int VIPSeats {  get; set; }

        public Flight(string name, DateOnly departureDay, DateOnly arrivalDate, double distance, TimeSpan timeTravel, int standardSeats = 70, int businessSeats = 20, int vipSeats = 10)
        {
            Id = Helper.generateID();
            Name = name;
            DepartureDate = departureDay;
            ArrivalDate = arrivalDate;
            Distance = distance;
            TimeTravel = timeTravel;
            StandardSeats = standardSeats;
            BusinessSeats = businessSeats;
            VIPSeats = vipSeats;
        }

        public static void showFlights(List<Flight> flights)
        {
            foreach(Flight flight in flights)
            {
                Console.WriteLine($"{flight.Id} - {flight.Name} - {flight.DepartureDate} - {flight.ArrivalDate} - {flight.Distance} - {flight.TimeTravel} ");
            }
        }

        public static void showAvaibleFlights(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {   if(flight.StandardSeats > 0 || flight.BusinessSeats > 0 || flight.VIPSeats > 0)
                Console.WriteLine($"{flight.Id} - {flight.Name} - {flight.DepartureDate} - {flight.ArrivalDate} - {flight.Distance} - {flight.TimeTravel} ");
            }
        }
    }

    

}
