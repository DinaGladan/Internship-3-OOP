
namespace Airport.Classes
{
    public class FlightHelper
    {
        public static List<Flight> showAvailableFlights(List<Flight> flights)
        {
            List<Flight> avaiableFlights = new List<Flight>();
            foreach (Flight flight in flights)
            {
                var standard_free = flight.Plane.Seats[SeatType.Standard] - flight.TakenStandardSeats;
                var business_free = flight.Plane.Seats[SeatType.Business] - flight.TakenBusinessSeats;
                var VIP_free = flight.Plane.Seats[SeatType.VIP] - flight.TakenVIPSeats;
                if (standard_free > 0 || business_free > 0 || VIP_free > 0)
                {
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
            if ((wanted_flight.Plane.Seats[SeatType.Standard]- wanted_flight.TakenStandardSeats) > 0)
            {
                Console.WriteLine($"Standardnih {wanted_flight.Plane.Seats[SeatType.Standard] - wanted_flight.TakenStandardSeats}");
                possible_seat.Add('s');
            }
            if ((wanted_flight.Plane.Seats[SeatType.Business] - wanted_flight.TakenBusinessSeats) > 0)
            {
                Console.WriteLine($"Busines {wanted_flight.Plane.Seats[SeatType.Business] - wanted_flight.TakenBusinessSeats}");
                possible_seat.Add('b');
            }
            if ((wanted_flight.Plane.Seats[SeatType.VIP] - wanted_flight.TakenVIPSeats) > 0)
            {
                Console.WriteLine($"VIP {wanted_flight.Plane.Seats[SeatType.VIP] - wanted_flight.TakenVIPSeats}");
                possible_seat.Add('v');
            }
            char seat_type = Helper.IsItChar(possible_seat);

           if(seat_type == 's')
                wanted_flight.TakenStandardSeats += 1;
           else if(seat_type =='b')
                wanted_flight.TakenBusinessSeats += 1;
           else if (seat_type =='v')
                wanted_flight.TakenVIPSeats += 1;

            return seat_type;
        }
        public static Flight findById(List<Flight> flights)
        {
            while (true)
            {
                Flight.showFlights(flights);
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
                if (String.IsNullOrEmpty(wanted_name))
                    break;
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
                    Flight.showFlights(flights_list);
                    var wanted_flights = findByName(flights_list);
                    Flight.showFlights(wanted_flights);
                    break;
            }
        }

        public static Flight CreateNewFlight(List<Crew> crew_list, List<Plane> planes, List<Flight> flights) 
        {
            Console.Write("Unesite naziv novog leta ");
            string name = Console.ReadLine();
            Helper.IsItString(name);

            Console.Write("Unesite datum polaska novog leta ");
            DateTime departure_day = Helper.IsValidDateAndTime();

            Console.Write("Unesite datum dolaska novog leta ");
            DateTime arrival_day = Helper.IsValidDateAndTime();

            Console.Write("Unesite udaljenost novog leta u kilometrima ");
            double distance = Helper.IsItDouble();
           
            Console.Write("Unesite trajanje leta. Unosite sate i minute (sekunde nisu obvezne):");
            TimeSpan travel_time = Helper.IsItTimeSpan();


            Plane plane;
            do
            {
                var available_plane = GetFreePlanes(planes, flights);
                Console.Clear();
                Console.WriteLine("Unesite naziv zeljenog aviona (izaberite od postojecih):");
                plane = WantedAirplane(available_plane);
            }
            while (plane == null);

            Crew flight_crew;
            do
            {
                var available_crew = GetFreeCrews(crew_list, flights);
                Console.Clear();
                Console.WriteLine("Unesite naziv zeljene posade novog leta (izaberite od postojecih):");
                flight_crew = WantedFlightCrew(available_crew);
            }
            while (flight_crew == null);

            return new Flight(name, departure_day, arrival_day, distance, travel_time, flight_crew, plane);
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
                    DateTime departure_day_edit = Helper.IsValidDateAndTime();
                    if (Helper.Confirm())
                    {
                        edit_flight.changeDepartureDate(departure_day_edit);
                        edit_flight.UpdateIt();
                    }
                    break;
                case 'b':
                    Console.Write("Unesite novi datum dolaska leta ");
                    DateTime arrival_day_edit = Helper.IsValidDateAndTime();
                    if (Helper.Confirm())
                    {
                        edit_flight.UpdateIt();
                        edit_flight.changeArrivalDate(arrival_day_edit);
                    }
                    break;
                case 'c':
                    Console.WriteLine("Posada vaseg leta: ");
                    Crew crew_to_edit = edit_flight.FlightCrew;
                    crew_to_edit.showCrew();
                    Helper.ReadyToContinue();
                    Crew new_crew = Crew.changeCrew(crew_to_edit, crews, flights);
                    if (Helper.Confirm())
                    {
                        edit_flight.UpdateIt();
                        edit_flight.FlightCrew = new_crew;
                    }
                    break;
            }
            Console.Clear();
            Console.WriteLine("Vas let poslije uredjivaanja: ");
            edit_flight.printFlight();
            edit_flight.FlightCrew.showCrew();
        }

        public static void deleteFlight(List<Flight> flights)
        {
            var delete_flight = findById(flights);
            while (unsatisfied_conditions(delete_flight))
            {
                Console.Clear();
                Console.WriteLine("Broj putnika na tom letu treba bit manji od 50% i vrijeme polaska treba bit vise od 24h");
                delete_flight = findById(flights);
            }
            if(Helper.Confirm())
                flights.Remove(delete_flight);
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

        public static Plane WantedAirplane(List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                plane.printPlane();
            }
            string wanted = Console.ReadLine();
            wanted = Helper.IsItString(wanted);
            foreach (var plane in planes)
            {
                if (plane.Name == wanted)
                {
                    Plane wanted_plane = plane;
                    return wanted_plane;
                }
            }
            return null;

        }

        public static List<Plane> GetFreePlanes(List<Plane> allPlanes, List<Flight> allFlights)
        {
            return allPlanes
                .Where(plane => allFlights.All(flight => flight.Plane != plane))
                .ToList();
        }

        public static List<Crew> GetFreeCrews(List<Crew> allCrews, List<Flight> allFlights)
        {
            return allCrews
                .Where(crew => allFlights.All(flight => flight.FlightCrew != crew))
                .ToList();
        }

        public static bool unsatisfied_conditions(Flight delete_f)
        {
            var sum_seats = delete_f.Plane.Seats.Values.Sum();
            decimal taken_seats = delete_f.TakenStandardSeats + delete_f.TakenBusinessSeats + delete_f.TakenVIPSeats;
            decimal percent = taken_seats / (decimal)sum_seats;
            if (percent > (decimal)0.5)
                return true;
            var houers = (delete_f.DepartureDate - DateTime.Now).TotalHours;
            if (houers < 24)
                return true;
            return false;
        }
    }
}
