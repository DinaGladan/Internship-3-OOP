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
                Console.Clear();
                Console.WriteLine("Unesite zeljeni izbor: ");
            }
            return c;
        }
        public static void PrintTitle(string t) {
            Console.WriteLine(t.ToUpper());
        }
        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string IsItString(string word) {;
            while(true) {
                
                if(!int.TryParse(word, out _)){
                    break;
                }
                Console.WriteLine("Unesite rijec, ne broj ");
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
    }
}
