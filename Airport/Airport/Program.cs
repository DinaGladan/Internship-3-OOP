using Airport.Classes;  //samostalno dodat
namespace Airport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var passengers_list = new List<Passenger>
            {
                new Passenger("Dina", "Gladan",new DateOnly(2004,02,20), "dina.gladan@gmail.com","pas1!sWord"),
                new Passenger("Ivan", "Nince",new DateOnly(2004,10,24), "ivan.nince@gmail.com","pas1!sWord"),
                new Passenger("Marko", "Gelot",new DateOnly(2007,07,14), "marko.gelot@gmail.com","pas1!sWord"),
            };

            int choice = Helper.Menu("1 - Putnici", "2 - Letovi", "3 – Avioni", "4 – Posada", "5 – Izlaz iz programa");
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    PassengersChoices(passengers_list);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Odabrali ste Letove");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Odabrali ste Avione");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Odabrali ste Posadu");
                    break;
                case 5:
                    Console.Clear();
                    Environment.Exit(0);// podaci ostanu lebdit popravi
                    break;
            }
        }
        static void PassengersChoices(List<Passenger> passengers)
        {
            Console.WriteLine("PUTNICI");
            int choice_p = Helper.Menu("1 - Registracija", "2 - Prijava", "3 - Izlaz iz opcije Putnika");
            switch (choice_p)
            {
                case 1:
                    passengers = PassengerHelper.PassangerRegistration(passengers);
                    Console.WriteLine("Trenutni putnici:");
                    foreach (Passenger p in passengers)
                        p.printPassenger();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
