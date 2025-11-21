namespace Airport.Classes
{
    public class Flight :BaseEntity
    {
        private string Id {  get; set; }
        public string Name { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Distance { get; set; }
        public TimeSpan TimeTravel { get; set; }
        public Crew FlightCrew {  get; set; }
        public Plane Plane { get; set; }
        public int TakenStandardSeats;
        public int TakenBusinessSeats;
        public int TakenVIPSeats;

        public Flight(string name, DateTime departureDay, DateTime arrivalDate, double distance, TimeSpan timeTravel, Crew flightCrew, Plane plane, int takenStandardSeats = 2, int takenBusinessSeats = 2, int takenVIPSeats=0) : base()
        {
            Id = Helper.generateID();
            Name = name;
            DepartureDate = departureDay;
            ArrivalDate = arrivalDate;
            Distance = distance;
            TimeTravel = timeTravel;
            FlightCrew = flightCrew;
            Plane = plane;
            TakenStandardSeats = takenStandardSeats;
            TakenBusinessSeats = takenBusinessSeats;
            TakenVIPSeats = takenVIPSeats;
        }

        public void UpdateFlight(string name, DateTime departureDay, DateTime arrivalDate, double distance, TimeSpan timeTravel, Crew flightCrew, Plane plane, int takenStandardSeats = 2, int takenBusinessSeats = 2, int takenVIPSeats = 0)
        {
            Name = name;
            DepartureDate = departureDay;
            ArrivalDate = arrivalDate;
            Distance = distance;
            TimeTravel = timeTravel;
            FlightCrew = flightCrew;
            Plane = plane;
            TakenStandardSeats = takenStandardSeats;
            TakenBusinessSeats = takenBusinessSeats;
            TakenVIPSeats = takenVIPSeats;
            UpdateIt();
        }

        public string getID()
        {
            return Id;
        }

        public void printFlight()
        {
            Console.WriteLine($"{Id} - {Name} - {DepartureDate} - {ArrivalDate} - {Distance} - {TimeTravel} ");
        }

        public void changeDepartureDate(DateTime departure_day_edit)
        {
            DepartureDate = departure_day_edit;
        }
        public void changeArrivalDate(DateTime arrival_day_edit)
        {
            ArrivalDate = arrival_day_edit;
        }

        public static void showFlights(List<Flight> flights)
        {
            foreach(Flight flight in flights)
            {
                Console.WriteLine($"{flight.Id} - {flight.Name} - {flight.DepartureDate} - {flight.ArrivalDate} - {flight.Distance} - {flight.TimeTravel} ");
            }
        }

        

    }

    

}
