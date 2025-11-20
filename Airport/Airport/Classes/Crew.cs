namespace Airport.Classes
{
    public class Crew
    {
        public string CrewName { get; set; }
        public List<CrewMember> CrewMembers { get; set; }

        public Crew(string crewName, List<CrewMember> crewMembers) {
            CrewName = crewName;
            CrewMembers = crewMembers;
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
                Console.WriteLine("Unesite zeljenu posadu (izaberite od mogucih): ");
                new_crew = FlightHelper.WantedFlightCrew(free_crews);
            }
            while (new_crew == null);
            return new_crew;
        }
    }

}
