
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
    }
}
