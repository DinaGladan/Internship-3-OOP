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

                int choice = Helper.Menu("1 - Putnici", "2 - Letovi", "3 – Avioni", "4 – Posada", "5 – Izlaz iz programa");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        PassengersChoices(passengers_list);
                        Helper.PrintTitle("glavni izbornik");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Odabrali ste Letove");
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
        static void PassengersChoices(List<Passenger> passengers)
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
                        break;
                    case 3:
                        loop = false;
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
