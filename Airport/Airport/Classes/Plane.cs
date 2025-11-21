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

        public static void showPlanes(List<Plane> planes)
        {
            foreach (Plane plane in planes)
            {
                Console.WriteLine($"{plane.Id} - {plane.Name} - {plane.ProductionYear} - {plane.NumberOfFlights}");
            }
        }

        public string getID()
        {
            return Id;
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
        public static void searchPlane(List<Plane> planes)
        {
            Console.WriteLine("Pretraživanje aviona \r\na) Po id-u \r\nb) Po nazivu");
            var possible_char = new List<char>() { 'a', 'b' };
            var choice = Helper.IsItChar(possible_char);

            switch (choice)
            {
                case 'a':
                    Console.Clear();
                    var wanted_plane = PlaneHelper.findById(planes);
                    wanted_plane.printPlane();
                    break;
                case 'b':
                    Console.Clear();
                    var wanted_planes = PlaneHelper.findByName(planes);
                    Plane.showPlanes(wanted_planes);
                    break;
            }
        }

        public static void deletePlane(List<Plane> planes)
        {
            Console.WriteLine("Brisanje aviona \r\na) Po id-u \r\nb) Po nazivu");
            var possible_char = new List<char>() { 'a', 'b' };
            var choice = Helper.IsItChar(possible_char);

            switch (choice)
            {
                case 'a':
                    Console.Clear();
                    var delete_plane = PlaneHelper.findById(planes);
                    planes.Remove(delete_plane);
                    break;
                case 'b':
                    Console.Clear();
                    var wanted_planes = PlaneHelper.findByName(planes);
                    planes.RemoveAll(p => wanted_planes.Contains(p));
                    break;
            }
            
        }
    }
   
}
