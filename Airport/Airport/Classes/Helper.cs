using System.Globalization;

namespace Airport.Classes
{
    public static class Helper
    {
        public static int Menu(params string[] choices) //params nam kaze dae lista stringova, neodredjen broj
        {
            foreach (var choice in choices)
            {
                Console.WriteLine(choice);
            }
            int c;
            while (!int.TryParse(Console.ReadLine(), out c) || c < 1 || c > choices.Length)
            {
                Console.WriteLine("Unesite zeljeni izbor: ");
            }
            return c;
        }
        public static void PrintTitle(params string[] title) {
            foreach(var t in title)
                Console.WriteLine(t.ToUpper() + "\n");
        }
        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string IsItString(string word) {;
            while(true) {
                
                if(!int.TryParse(word, out _) && !string.IsNullOrEmpty(word) && !string.IsNullOrWhiteSpace(word)){
                    break;
                }
                Console.Write("Unesite rijec ");
                word = Console.ReadLine();
            }
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(word);
        }

        public static DateOnly IsValidDate()
        {
            DateOnly bd;
            while (true)
            {   
                string date = Console.ReadLine();
                if (DateOnly.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out bd) && bd < DateOnly.FromDateTime( DateTime.Now))
                    return bd;
                else {
                    Console.WriteLine("Niste unijeli datum u ispravnom formatu ili ste unijeli previsoku godinu ");
                    Console.Write("Unesite datum rodjenja korisnika (YYYY-MM-DD) ");
                }
            }
        }
        public static void ReadyToContinue()
        {
            Console.WriteLine("\nPritisnite enter za nastavak ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Clear();
        }

        public static Flight findById(List<Flight> flights)
        {
            while (true)
            {
                Console.Write("Unesite jedan od ponudjenih IDieva: ");
                string wanted_id = Console.ReadLine();
                foreach (Flight flight in flights)
                {
                    if (flight.getID() == wanted_id)
                    {
                        return flight;
                    }
                }
                Console.WriteLine();
            }
        }

        public static char IsItChar(List<char> possible_char)
        {   
            char c;
            while(!char.TryParse(Console.ReadLine().Trim().ToLower(), out c) || !possible_char.Contains(c))
            {
                Console.WriteLine("Potrebno je unijeti " + string.Join(",", possible_char).ToUpper());
            }
            return c;
        }
    }
}
