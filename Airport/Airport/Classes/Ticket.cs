namespace Airport.Classes
{
    public class Ticket : BaseEntity
    {
        private string Id { get; set; }
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public char Seat_type { get; set; }

        public Ticket(Passenger passenger, Flight flight, char seat_type) : base()
        {
            Id = Helper.generateID();
            Passenger = passenger;
            Flight = flight;
            Seat_type = seat_type;
        }
        public void UpdateTicket(Passenger passenger, Flight flight, char seat_type)
        {
            Id = Helper.generateID();
            Passenger = passenger;
            Flight = flight;
            Seat_type = seat_type;
            UpdateIt();
        }

        public void printTicket()
        {
            Console.WriteLine($"Na letu {Flight.Name}, {Passenger.Name} {Passenger.Surname} ima sjedalo {Seat_type.ToString().ToUpper()} tipa. ");
        }
    }
    
}
