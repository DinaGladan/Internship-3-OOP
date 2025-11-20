using Airport.Classes.Members;
namespace Airport.Classes
{
    public class CrewHelper
    {
        public static Pilot WantedPilot(List<Pilot> pilots)
        {
            foreach (var pilot in pilots)
            {
                pilot.printMember();
            }
            string wanted = Console.ReadLine();
            foreach (var pilot in pilots)
            {
                if (pilot.getId() == wanted)
                {
                    Pilot wanted_pilot = pilot;
                    return wanted_pilot;
                }
            }
            return null;

        }

        public static CoPilot WantedCoPilot(List<CoPilot> copilots)
        {
            foreach (var copilot in copilots)
            {
                copilot.printMember();
            }
            string wanted = Console.ReadLine();
            foreach (var copilot in copilots)
            {
                if (copilot.getId() == wanted)
                {
                    CoPilot wanted_copilot = copilot;
                    return wanted_copilot;
                }
            }
            return null;

        }

        public static Stewardess WantedStewardess(List<Stewardess> stewardesses)
        {
            foreach (var stew in stewardesses)
            {
                stew.printMember();
            }
            string wanted = Console.ReadLine();
            foreach (var stew in stewardesses)
            {
                if (stew.getId() == wanted)
                {
                    Stewardess wanted_stew = stew;
                    return wanted_stew;
                }
            }
            return null;

        }

        public static List<Pilot> GetFreePilots(List<Crew> allCrews, List<Pilot> allPilots)
        {
            return allPilots
                .Where(pilot => allCrews.All(crew => !crew.CrewMembers.Contains(pilot)))
                .ToList();
        }
        public static List<CoPilot> GetFreeCoPilots(List<Crew> allCrews, List<CoPilot> allCoPilots)
        {
            return allCoPilots
                .Where(coPilot => allCrews.All(crew => !crew.CrewMembers.Contains(coPilot)))
                .ToList();
        }
        public static List<Stewardess> GetFreeStewardesses(List<Crew> allCrews, List<Stewardess> allStews)
        {
            return allStews
                .Where(stew => allCrews.All(crew => !crew.CrewMembers.Contains(stew)))
                .ToList();
        }

        public static void AddStaff(List<Pilot> pilots, List<CoPilot> copilots, List<Stewardess> stewardesses)
        {
            int c = Helper.Menu("1 - Za dodavanje pilota", "2 - Za dodavanje kopilota", "3 - Za dodavanje stjuardese");
            switch (c)
            {
                case 1:
                    Console.Clear();
                    Helper.PrintTitle("dodavanje pilota");

                    Console.Write("Unesite ime novog pilota ");
                    string pilot_name = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite prezime novog pilota ");
                    string pilot_surname = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite spol novog pilota ");
                    string pilot_gender = Helper.IsGender(Console.ReadLine());

                    Console.Write("Unesite datum rodjenja pilota (YYYY-MM-DD) ");
                    DateOnly pilot_birth = Helper.IsValidBirthDate();

                    var new_pilot = new Pilot(pilot_name,pilot_surname,pilot_gender,pilot_birth);
                    pilots.Add(new_pilot);

                    Console.WriteLine("\nPiloti u sustavu: ");
                    foreach (var pilot in pilots)
                        pilot.printMember();

                    break;
                case 2:
                    Console.Clear();
                    Helper.PrintTitle("dodavanje kopilota");

                    Console.Write("Unesite ime novog kopilota ");
                    string copilot_name = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite prezime novog kopilta ");
                    string copilot_surname = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite spol novog kopilota ");
                    string copilot_gender = Helper.IsGender(Console.ReadLine());

                    Console.Write("Unesite datum rodjenja kopilota (YYYY-MM-DD) ");
                    DateOnly copilot_birth = Helper.IsValidBirthDate();

                    var new_copilot = new CoPilot(copilot_name, copilot_surname, copilot_gender, copilot_birth);
                    copilots.Add(new_copilot);

                    Console.WriteLine("\nKopiloti u sustavu:");
                    foreach (var copilot in copilots)
                        copilot.printMember();

                    break;
                case 3:
                    Console.Clear();
                    Helper.PrintTitle("dodavanje sjuardese");

                    Console.Write("Unesite ime novoe stjuardese ");
                    string stew_name = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite prezime nove stjuardese ");
                    string stew_surname = Helper.IsItString(Console.ReadLine());

                    Console.Write("Unesite spol novoe stjuardese ");
                    string stew_gender = Helper.IsGender(Console.ReadLine());

                    Console.Write("Unesite datum rodjenja novoe stjuardese (YYYY-MM-DD) ");
                    DateOnly stew_birth = Helper.IsValidBirthDate();

                    var new_stew = new Stewardess(stew_name, stew_surname, stew_gender, stew_birth);
                    stewardesses.Add(new_stew);

                    Console.WriteLine("\nStjuardese u sustavu:");
                    foreach (var stew in stewardesses)
                        stew.printMember();

                    break;
            }
        }

    }
}
