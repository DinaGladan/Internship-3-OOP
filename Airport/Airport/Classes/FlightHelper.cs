namespace Airport.Classes
{
    public class FlightHelper
    {
        public static List<Flight> showAvailableFlights(List<Flight> flights)
        {
            List<Flight> avaiableFlights = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (flight.StandardSeats > 0 || flight.BusinessSeats > 0 || flight.VIPSeats > 0)
                {
                    Console.WriteLine($"{flight.Id} - {flight.Name} - {flight.DepartureDate} - {flight.ArrivalDate} - {flight.Distance} - {flight.TimeTravel} ");
                    avaiableFlights.Add(flight);

                }
            }
            Console.WriteLine();

            return avaiableFlights;
        }

        public static Flight chooseFromAvailableFlights(List<Flight> availableFlights)
        {
            Flight wanted_flight = Helper.findById(availableFlights);
            return wanted_flight;
        }

        public static char chooseAvailableSeat(Flight wanted_flight)
        {
            var possible_seat = new List<char>();

            Console.WriteLine("Dostupna kategorija (Unesite S za standard, B za business ili V za VIP) : ");
            if ((70 - wanted_flight.StandardSeats) > 0)
            {
                Console.WriteLine($"Standardnih {70 - wanted_flight.StandardSeats}");
                possible_seat.Add('s');
            }
            if ((20 - wanted_flight.BusinessSeats) > 0)
            {
                Console.WriteLine($"Busines {20 - wanted_flight.BusinessSeats}");
                possible_seat.Add('b');
            }
            if ((10 - wanted_flight.VIPSeats) > 0)
            {
                Console.WriteLine($"VIP {10 - wanted_flight.VIPSeats}");
                possible_seat.Add('v');
            }
            char seat_type = Helper.IsItChar(possible_seat);
            return seat_type;
        }

    }
}
