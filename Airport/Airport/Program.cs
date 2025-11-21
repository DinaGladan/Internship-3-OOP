using Airport.Classes;  //samostalno dodat
using Airport.Classes.Members;
using System.Collections.Generic;
namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var pilots = new List<Pilot>() {
                    new Pilot("Linda", "Klamar","zensko",new DateOnly(2004,02,20)),
                    new Pilot("Tani", "Klamar","zensko",new DateOnly(2004,02,20)),
                    new Pilot("Valent", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Pilot("Vedran", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Pilot("Irena", "Klamar","zensko",new DateOnly(2004,02,20)),
            };
            var copilots = new List<CoPilot>() {
                    new CoPilot("Fani", "Flamar","zensko",new DateOnly(2004,02,20)),
                    new CoPilot("Rahela", "Klamar","zensko",new DateOnly(2004,02,20)),
                    new CoPilot("Marko", "Klamar","musko",new DateOnly(2004,02,20)),
                    new CoPilot("Šime", "Klamar","musko",new DateOnly(2004,02,20)),
                    new CoPilot("Ivica", "Klamar","musko",new DateOnly(2004,02,20)),
                    new CoPilot("Mislav", "Klamar","musko",new DateOnly(2004,02,20)),
            };
            var stewardesses = new List<Stewardess>() {
                    new Stewardess("Chiara", "Klamar","zensko",new DateOnly(2004,02,20)),
                    new Stewardess("Klara", "Klamar","zensko",new DateOnly(2004,02,20)),
                    new Stewardess("Karlo", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Miso", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Silvio", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Alen", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Mihael", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Luka", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Mirko", "Klamar","musko",new DateOnly(2004,02,20)),
                    new Stewardess("Bepo", "Klamar","musko",new DateOnly(2004,02,20)),
            };
            var passengers_list = new List<Passenger>
            {
                    new Passenger("Dina", "Gladan",new DateOnly(2004,02,20), "dina.gladan@gmail.com","pas1!sWord"),
                    new Passenger("Ivan", "Nince",new DateOnly(2004,10,24), "ivan.nince@gmail.com","pas1!sWord"),
                    new Passenger("Marko", "Gelot",new DateOnly(2007,07,14), "marko.gelot@gmail.com","pas1!sWord"),
            };

            var crew_list = new List<Crew>
            {
                    new Crew("Posada1",new List<CrewMember>{
                        pilots[0],
                        copilots[0],
                        stewardesses[0],
                        stewardesses[1],
                    } ),
                    new Crew("Posada2",new List<CrewMember>{
                        pilots[1],
                        copilots[1],
                        stewardesses[2],
                        stewardesses[3],
                    } ),
                    new Crew("Posada3",new List<CrewMember>{
                        pilots[2],
                        copilots[2],
                        stewardesses[4],
                        stewardesses[5],
                    } ),
                    new Crew("Posada4",new List<CrewMember>{
                        pilots[3],
                        copilots[3],
                        stewardesses[6],
                        stewardesses[7],
                    } ),
            };

            var planes_list = new List<Plane>
            {
                new Plane("Avion_1", 2013,223, new Dictionary<SeatType, int>
                {
                    {SeatType.Standard,70 },
                    { SeatType.Business, 20},
                    { SeatType.VIP,10},
                }),
                new Plane("Avion_2", 2014,253, new Dictionary<SeatType, int>
                {
                    {SeatType.Standard,70 },
                    { SeatType.Business, 20},
                    { SeatType.VIP,10},
                }),
                new Plane("Avion_3", 2012,123, new Dictionary<SeatType, int>
                {
                    {SeatType.Standard,70 },
                    { SeatType.Business, 20},
                    { SeatType.VIP,10},
                }),
                new Plane("Avion_4", 2012,123, new Dictionary<SeatType, int>
                {
                    {SeatType.Standard,70 },
                    { SeatType.Business, 20},
                    { SeatType.VIP,10},
                }),

            };

            var flights_list = new List<Flight>
            {
                    new Flight( "Zagreb - London", new DateTime(2025,11,21,12,20,0), new DateTime(2025,12,10,16,12,0), 1450, new TimeSpan(2,20,0), crew_list[0], planes_list[0], 70,20,10),
                    new Flight( "Zagreb - Paris", new DateTime(2025,11,22,12,20,0), new DateTime(2025,12,10,16,12,0), 1450, new TimeSpan(2,20,0), crew_list[1],planes_list[1],45,12,10),
                    new Flight( "Split - Dubai", new DateTime(2025,11,21,12,20,0), new DateTime(2025,12,10,16,12,0), 1450, new TimeSpan(2,20,0), crew_list[2],planes_list[2],67,6,7),
            };

            Helper.PrintTitle("glavni izbornik");
            bool loop = true;
            while (loop)
            {   
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
                        FlightsChoices(flights_list, crew_list, planes_list);
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 3:
                        Console.Clear();
                        PlanesChoices(planes_list);
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 4:
                        Console.Clear();
                        CrewChoice(pilots, copilots, stewardesses, crew_list);;
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

        static void FlightsChoices(List<Flight> flights, List<Crew>crews, List<Plane> planes)
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
                        Flight new_flight = FlightHelper.CreateNewFlight(crews,planes, flights);
                        flights.Add(new_flight);
                        Helper.ReadyToContinue();
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
                        FlightHelper.editFlight(flights, crews);
                        Helper.ReadyToContinue();
                        break;
                    case 5:
                        Console.Clear();
                        Helper.PrintTitle("Brisanje letova");
                        Console.WriteLine("Prikaz postojecih letova: ");
                        Flight.showFlights(flights);
                        FlightHelper.deleteFlight(flights);
                        Helper.ReadyToContinue();
                        break;
                    case 6:
                        loop = false;
                        Console.Clear();
                        break;
                }
            }

        }
        static void CrewChoice(List<Pilot> pilots, List<CoPilot> copilots, List<Stewardess> stewardesses, List<Crew> crew_list)
        {
            bool loop = true;
            while (loop)
            {
                Helper.PrintTitle("posada");
                int choice_f = Helper.Menu("1 - Prikaz svih posada", "2 - Kreiranje nove posade", "3 - Dodavanje novog osoblja", "4 - Povratak na prethodni izbornik");
                switch (choice_f)
                {
                    case 1:
                        Console.Clear();
                        Helper.PrintTitle("Prikaz svih posada");
                        foreach(var crew in crew_list)
                        {
                            crew.showCrew();
                        }
                        Helper.ReadyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        Helper.PrintTitle("Kreiranje nove posade");
                        var new_crew = Crew.createNewCrew(pilots, copilots, stewardesses, crew_list);
                        crew_list.Add(new_crew);
                        Helper.ReadyToContinue();
                        break;
                    case 3:
                        Console.Clear();
                        Helper.PrintTitle("Dodavanje novog osoblja");
                        CrewHelper.AddStaff(pilots, copilots, stewardesses);
                        Helper.ReadyToContinue();
                        break;
                    case 4:
                        loop = false;
                        Console.Clear();
                        break;
                    
                }
            }
        }

        static void PlanesChoices(List<Plane> planes)
        {
            bool loop = true;
            while (loop)
            {
                Helper.PrintTitle("avioni");
                int choice_f = Helper.Menu("1 - Prikaz svih aviona", "2 - Dodavanje novog aviona", "3 - Pretrazivanje aviona", "4 - Brisanje aviona", "5 - Povratak na prethodni izbornik");
                switch (choice_f)
                {
                    case 1:
                        Console.Clear();
                        Helper.PrintTitle("Prikaz svih aviona");
                        foreach (var plane in planes)
                        {
                            plane.printPlane();
                        }
                        Helper.ReadyToContinue();
                        break;
                    case 2:
                        Console.Clear();
                        Helper.PrintTitle("Dodavanje novog aviona");
                        Plane.addPlane(planes);
                        Helper.ReadyToContinue();
                        break;
                    case 3:
                        Console.Clear();
                        Helper.PrintTitle("Pretrazivanje aviona");
                        Plane.searchPlane(planes);
                        Helper.ReadyToContinue();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        loop = false;
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
