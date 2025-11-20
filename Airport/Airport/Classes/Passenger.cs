
namespace Airport.Classes
{
    public class Passenger
    {
        private string Id { get; set; }
        public string Name {  get; set; }
        public string Surname { get; set; }
        private DateOnly Birthdate { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        public List<Ticket> PassengerTickets { get; set; } = new List<Ticket>();

        public Passenger(string name, string surname, DateOnly birthdate, string email, string password) {
            Id = Helper.generateID();
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Email = email;
            Password = password;
        }
        public void printPassenger() {
            Console.WriteLine($"Name: {Name} Surname: {Surname} BirthDate: {Birthdate} Email: {Email}");
        }
        public string get_pas()
        {
            return Password;
        }

        public void printTickets()
        {
            foreach(Ticket ticket in PassengerTickets) { 
                ticket.printTicket();
            }
        }

        public void cancelTicket(List<Flight> flights)
        {
            Console.WriteLine("\nMozete otkazat letove najmanje 24h ranije. ");
            var cancel_flights_by_name = FlightHelper.findByName(flights);

            if (cancel_flights_by_name.Count() == 0)
            {
                Console.WriteLine("Let tog imena ne postoji");
                return;
            }
            Flight flight_to_cancel = cancel_flights_by_name[0];
            DateTime departure_date = flight_to_cancel.DepartureDate.ToDateTime(TimeOnly.MinValue);
            TimeSpan difference = departure_date - DateTime.Now;
            if (difference.TotalHours<24)
            {
                Console.WriteLine("Leta treba bit najmanje 24 sata ranije kako biste ga otkazali");
                return;
            }
            Ticket? ticketToRemove = PassengerTickets.FirstOrDefault(t => t.Flight == flight_to_cancel);
            if (ticketToRemove == null)
            {
                Console.WriteLine("Nemate rezervaciju za taj let");
                return;
            }
            PassengerTickets.Remove(ticketToRemove);
            Console.WriteLine($"Otkazan {flight_to_cancel.Name}");
        }
    }
}
