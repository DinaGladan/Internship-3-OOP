using Airport.Classes;  //samostalno dodat
namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintTitle("glavni izbornik");
            bool loop = true;
            while (loop)
            {
                var passengers_list = new List<Passenger>
                {
                    new Passenger("Dina", "Gladan",new DateOnly(2004,02,20), "dina.gladan@gmail.com","pas1!sWord"),
                    new Passenger("Ivan", "Nince",new DateOnly(2004,10,24), "ivan.nince@gmail.com","pas1!sWord"),
                    new Passenger("Marko", "Gelot",new DateOnly(2007,07,14), "marko.gelot@gmail.com","pas1!sWord"),
                };

                var flights_list = new List<Flight>
                {
                    new Flight( "Zagreb - London", new DateOnly(2025,12,01), new DateOnly(2025,12,10), 1450, new TimeSpan(2,20,0), 66,20,10 ),
                    new Flight( "Zagreb - Paris", new DateOnly(2025,12,01), new DateOnly(2025,12,10), 1450, new TimeSpan(2,20,0), 36,4,1 ),
                    new Flight( "Split - Dubai", new DateOnly(2025,12,01), new DateOnly(2025,12,10), 1450, new TimeSpan(2,20,0), 70,18,10 ),
                };

                int choice = Helper.Menu("1 - Putnici", "2 - Letovi", "3 – Avioni", "4 – Posada", "5 – Izlaz iz programa");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        PassengersChoices(passengers_list, flights_list);
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 2:
                        Console.Clear();
                        FlightsChoices(flights_list);
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Odabrali ste Avione");
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Odabrali ste Posadu");
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 5:
                        Console.Clear();
                        loop= false;
                        break;
                }
            }
        }
        static void PassengersChoices(List<Passenger> passengers, List<Flight> flights_list)
        {
            bool loop = true;
            while (loop)
            {
                Helper.PrintTitle("putnici");
                int choice_p = Helper.Menu("1 - Registracija", "2 - Prijava", "3 - Izlaz iz opcije Putnika");
                switch (choice_p)
                {
                    case 1:
                        passengers = PassengerHelper.PassangerRegistration(passengers);
                        Console.WriteLine("Trenutni putnici:\n");
                        foreach (Passenger p in passengers)
                            p.printPassenger();
                        Helper.ReadyToContinue();

                        break;
                    case 2:
                        Passenger? logged = null;
                        while (logged ==null) {
                            logged = PassengerHelper.PassengerLogIn(passengers);
                        }
                        Console.Clear();
                        
                        PassengerLogIn(logged, flights_list);
                        break;
                    case 3:
                        loop = false;
                        Console.Clear();
                        break;
                }
            }
        }
        static void PassengerLogIn(Passenger logged, List<Flight> flights_list)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Prijavljeni ste kao: ");
                logged.printPassenger();
                Console.WriteLine();
                var choice = Helper.Menu("1 - Prikaz svih letova", "2 - Odabir leta", "3 - Pretrazivanje letova (po ID-u ili po nazivu)", "4 - Otkazivanje leta", "5 - Povrtaka na prethodni izbornik");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Helper.PrintTitle("Prikaz svih letova"); //mozda treba samo od tog putnika??
                        Flight.showFlights(flights_list);
                        Helper.ReadyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        Helper.PrintTitle("Odabir leta od dostupnih");
                        var available_flights = FlightHelper.showAvailableFlights(flights_list);
                        var wanted_flight = FlightHelper.chooseFromAvailableFlights(available_flights);
                        var wanted_seat = FlightHelper.chooseAvailableSeat(wanted_flight);
                        Ticket new_ticket = new Ticket(logged, wanted_flight, wanted_seat);
                        logged.PassengerTickets.Add(new_ticket);
                        Console.Clear(); 
                        logged.printTickets(); //dodat da se smanji za jedan poslije odabira sjedala i da se ne moze vec odabrani let opet uzet?
                        Helper.ReadyToContinue();
                        break;
                    case 3:
                        Console.Clear();
                        Helper.PrintTitle("Pretrazivanje letova");
                        FlightHelper.searchFlight(flights_list);
                        Helper.ReadyToContinue();
                        break;
                    case 4:
                        Console.Clear();
                        Helper.PrintTitle("Otkazivanje letova");
                        logged.printTickets();
                        logged.cancelTicket(flights_list);
                        Helper.ReadyToContinue();
                        break;
                    case 5:
                        loop = false;
                        Console.Clear();
                        break;
                }
            }
        }

        static void FlightsChoices(List<Flight> flights)
        {
            bool loop = true;
            while(loop)
            {
                Helper.PrintTitle("letovi");
                int choice_f = Helper.Menu("1 - Prikaz svih letova", "2 - Dodavanje novog leta", "3 - Pretrazivanje leta", "4 - Uredjivanje letova" , "5 - Brisanje leta", "6 - Povratak na prethodni izbornik");
                switch (choice_f)
                {
                    case 1:
                        Console.Clear();
                        Helper.PrintTitle("Prikaz svih letova"); 
                        Flight.showFlights(flights);
                        Helper.ReadyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        Helper.PrintTitle("Dodavanje novog leta");
                        Flight new_flight = FlightHelper.CreateNewFlight();
                        flights.Add(new_flight);
                        break;
                    case 3:
                        Console.Clear();
                        Helper.PrintTitle("Pretrazivanje leta");
                        FlightHelper.searchFlight(flights);
                        Helper.ReadyToContinue();
                        break;
                    case 4:
                        Console.Clear();
                        Helper.PrintTitle("Uredjivanje letova");
                        Console.WriteLine("Prikaz postojecih letova: "); 
                        Flight.showFlights(flights);
                        FlightHelper.editFlight(flights);
                        break;
                    case 5:
                        break;
                    case 6:
                        loop = false;
                        Console.Clear();
                        break;
                }
            }

        }
    }
}
