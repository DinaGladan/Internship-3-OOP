namespace Airport.Classes.Members
{
    public class CoPilot : CrewMember
    {
        public override string Position => "CoPilot"; 
        public CoPilot(string name, string surname, string gender, DateOnly birthDate) : base(name, surname, gender, birthDate)
        {

        }
    }
}
