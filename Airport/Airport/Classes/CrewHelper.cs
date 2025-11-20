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

    }
}
