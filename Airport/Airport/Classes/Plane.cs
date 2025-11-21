namespace Airport.Classes
{
    public class Plane
    {
        private string Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int NumberOfFlights { get; set; }
        public Dictionary<SeatType, int> Seats { get; set; }

        public Plane(string name, int productionYear, int numberOfFlights, Dictionary<SeatType,int> seats)
        {
            Id = Helper.generateID();
            Name = name;
            ProductionYear = productionYear;
            NumberOfFlights = numberOfFlights;
            Seats = seats;
        }

        public void printPlane()
        {
            Console.WriteLine($"{Id} - {Name} - {ProductionYear} - {NumberOfFlights}");
        }

        public static void addPlane(List<Plane>planes)
        {
            Console.Write("Unesite naziv novog aviona ");
            string name = Console.ReadLine();
            name =Helper.IsItString(name);

            Console.Write("Unesite godinu proizvodnje novog leta ");
            int year = Helper.IsValidYear();

            Console.Write("Unesite broj odradjenih letova ");
            int number_of_flights = Helper.IsPositive();

            Console.Write("Unesite broj standardnih sjedala ");
            int standard_seats = Helper.IsPositive();

            Console.Write("Unesite broj biznis sjedala ");
            int business_seats = Helper.IsPositive();

            Console.Write("Unesite broj VIP sjedala ");
            int VIP_seats = Helper.IsPositive();

            var new_plane = new Plane(name, year, number_of_flights, new Dictionary<SeatType, int>
            {
                { SeatType.Standard,standard_seats },
                {SeatType.Business, business_seats },
                {SeatType.VIP, VIP_seats },
            });
            planes.Add(new_plane);
        }
    }
   
}
