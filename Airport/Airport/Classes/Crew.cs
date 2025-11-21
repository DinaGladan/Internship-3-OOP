using Airport.Classes.Members;
namespace Airport.Classes
{
    public class Crew : BaseEntity
    {
        public string CrewName { get; set; }
        public List<CrewMember> CrewMembers { get; set; }

        public Crew(string crewName, List<CrewMember> crewMembers) : base(){
            CrewName = crewName;
            CrewMembers = crewMembers;
        }
        public void UpdateCrew(string crewName, List<CrewMember> crewMembers) 
        {
            CrewName = crewName;
            CrewMembers = crewMembers;
            UpdateIt();
        }

        public void showCrew()
        {
            Console.WriteLine($"{CrewName}");
            foreach(var member in CrewMembers)
            {
                member.printMember();
            }
            Console.WriteLine();
        }

        public static Crew changeCrew(Crew crew_to_edit, List<Crew>crews, List<Flight>flights)
        {
           
            var free_crews = FlightHelper.GetFreeCrews(crews, flights);
            Crew new_crew;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite naziv zeljene posade (izaberite od mogucih): ");
                new_crew = FlightHelper.WantedFlightCrew(free_crews);
            }
            while (new_crew == null);
            return new_crew;
        }

        public static Crew createNewCrew(List<Pilot> pilots, List<CoPilot> copilots, List<Stewardess> stewardesses, List<Crew> crews)
        {
            Console.Write("Unesite naziv nove posade ");
            string crew_name = Console.ReadLine();
            crew_name = Helper.IsItString(crew_name);

            var members = new List<CrewMember>();
            var free_pilots = CrewHelper.GetFreePilots(crews, pilots);
            Pilot new_pilot;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite ID zeljenog pilota (izaberite od mogucih): ");
                new_pilot = CrewHelper.WantedPilot(free_pilots);
            } while (new_pilot == null);
            members.Add(new_pilot);

            var free_coPilots = CrewHelper.GetFreeCoPilots(crews, copilots);
            CoPilot new_coPilot;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite ID zeljenog kopilota (izaberite od mogucih): ");
                new_coPilot = CrewHelper.WantedCoPilot(free_coPilots);
            } while (new_coPilot == null);
            members.Add(new_coPilot);

            var free_stews = CrewHelper.GetFreeStewardesses(crews, stewardesses);
            Stewardess new_stew_first;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite ID za prvu stjuardesu (izaberite od mogucih): ");
                new_stew_first = CrewHelper.WantedStewardess(free_stews);
            } while (new_stew_first == null);
            members.Add(new_stew_first);
            free_stews.Remove(new_stew_first);

            Stewardess new_stew_second;
            do
            {
                Console.Clear();
                Console.WriteLine("Unesite ID za drugu stjuardesu (izaberite od mogucih): ");
                new_stew_second = CrewHelper.WantedStewardess(free_stews);
            } while (new_stew_second == null);

            members.Add(new_stew_second);
            return new Crew(crew_name, members);
        }
    }

}
