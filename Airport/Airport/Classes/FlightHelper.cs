
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
                    Console.WriteLine($"{flight.getID()} - {flight.Name} - {flight.DepartureDate} - {flight.ArrivalDate} - {flight.Distance} - {flight.TimeTravel} ");
                    avaiableFlights.Add(flight);

                }
            }
            Console.WriteLine();

            return avaiableFlights;
        }

        public static Flight chooseFromAvailableFlights(List<Flight> availableFlights)
        {
            Flight wanted_flight = findById(availableFlights);
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
        public static Flight findById(List<Flight> flights)
        {
            while (true)
            {
                Console.Write("Unesite jedan od postojecih IDieva: ");
                string wanted_id = Console.ReadLine();
                foreach (Flight flight in flights)
                {
                    if (flight.getID() == wanted_id)
                    {
                        return flight;
                    }
                }
                Console.WriteLine();
            }
        }

        public static List<Flight> findByName(List<Flight> flights)
        {
            bool loop = true;
            List<Flight> wanted_names= new List<Flight>();
            while (loop)
            {
                Console.Write("Unesite jedan od postojecih naziva letova: ");
                wanted_names = new List<Flight>();
                string wanted_name = Console.ReadLine();
                foreach (Flight flight in flights)
                {
                    if (flight.Name == wanted_name)
                    {
                        wanted_names.Add(flight);
                        loop = false;
                    }
                }
                Console.WriteLine();
            }
            return wanted_names;
        }
        public static void searchFlight(List<Flight> flights_list)
        {
            Console.WriteLine("Pretraživanje letova \r\na) Po id-u \r\nb) Po nazivu");
            var possible_char = new List<char>() { 'a', 'b' };
            var choice = Helper.IsItChar(possible_char);

            switch (choice)
            {
                case 'a':
                    Console.Clear();
                    var wanted_flight =findById(flights_list);
                    wanted_flight.printFlight();
                    break;
                case 'b':
                    Console.Clear();
                    var wanted_flights = findByName(flights_list);
                    Flight.showFlights(wanted_flights);
                    break;
            }
        }

        public static Flight CreateNewFlight(List<Crew> crew_list) // dodat avion
        {
            Console.Write("Unesite naziv novog leta ");
            string name = Console.ReadLine();
            Helper.IsItString(name);

            Console.Write("Unesite datum polaska novog leta ");
            DateOnly departure_day = Helper.IsValidDate();

            Console.Write("Unesite datum dolaska novog leta ");
            DateOnly arrival_day = Helper.IsValidDate();

            Console.Write("Unesite udaljenost novog leta u kilometrima ");
            double distance = Helper.IsItDouble();
           
            Console.Write("Unesite trajanje leta. Unosite sate i minute (sekunde nisu obvezne):");
            TimeSpan travel_time = Helper.IsItTimeSpan();
            Crew flight_crew;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite zeljenu posadu novog leta (izaberite od postojecih):");
                flight_crew = WantedFlightCrew(crew_list);
            }
            while (flight_crew == null);

            return new Flight(name, departure_day, arrival_day, distance, travel_time, flight_crew);
        }

        public static void editFlight(List<Flight> flights, List<Crew>crews)
        {
            var edit_flight = findById(flights);

            Console.Clear();
            Console.WriteLine("Uredjujemo let : ");
            edit_flight.printFlight();
            Console.WriteLine("\n");

            Console.WriteLine("Unesite izbor sto zelite urediti: \na) Vrijeme polaska \nb) Vrijeme dolaska \nc) Posadu");
            var possible_choices = new List<char>() { 'a', 'b', 'c' };
            var choice = Helper.IsItChar(possible_choices);
            switch (choice)
            {
                case 'a':
                    Console.Write("Unesite novi datum polaska leta ");
                    DateOnly departure_day_edit = Helper.IsValidDate();
                    edit_flight.changeDepartureDate(departure_day_edit);
                    break;
                case 'b':
                    Console.Write("Unesite novi datum dolaska leta ");
                    DateOnly arrival_day_edit = Helper.IsValidDate();
                    edit_flight.changeArrivalDate(arrival_day_edit);
                    break;
                case 'c':
                    Console.WriteLine("Posada vaseg leta: ");
                    Crew crew_to_edit = edit_flight.FlightCrew;
                    crew_to_edit.showCrew();
                    Helper.ReadyToContinue();
                    Crew new_crew = Crew.changeCrew(crew_to_edit, crews, flights);
                    edit_flight.FlightCrew = new_crew;;
                    break;
            }
            Console.WriteLine("Vas let poslije uredjivaanja: ");
            edit_flight.printFlight();
            edit_flight.FlightCrew.showCrew();
        }
        public static Crew WantedFlightCrew(List<Crew> crew_list)
        {
            foreach (var crew in crew_list)
            {
                crew.showCrew();
            }
            string wanted = Console.ReadLine();
            wanted = Helper.IsItString(wanted);
            foreach (var crew in crew_list)
            {
                if (crew.CrewName == wanted)
                {
                    Crew wanted_crew = crew;
                    return wanted_crew;
                }
            }
            return null;

        }
        public static List<Crew> GetFreeCrews(List<Crew> allCrews, List<Flight> allFlights)
        {
            return allCrews
                .Where(crew => allFlights.All(flight => flight.FlightCrew != crew))
                .ToList();
        }

    }
}
