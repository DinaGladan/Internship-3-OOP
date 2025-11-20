namespace Airport.Classes
{
    public class Flight
    {
        private string Id {  get; set; }
        public string Name { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Distance { get; set; }
        public TimeSpan TimeTravel { get; set; }
        public Crew FlightCrew {  get; set; }

        public int StandardSeats { get; set; }
        public int BusinessSeats { get; set; }
        public int VIPSeats {  get; set; }

        public Flight(string name, DateTime departureDay, DateTime arrivalDate, double distance, TimeSpan timeTravel, Crew flightCrew, int standardSeats = 70, int businessSeats = 20, int vipSeats = 10)
        {
            Id = Helper.generateID();
            Name = name;
            DepartureDate = departureDay;
            ArrivalDate = arrivalDate;
            Distance = distance;
            TimeTravel = timeTravel;
            FlightCrew = flightCrew;
            StandardSeats = standardSeats;
            BusinessSeats = businessSeats;
            VIPSeats = vipSeats;
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
