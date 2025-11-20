namespace Airport.Classes.Members
{
    public class Pilot : CrewMember
    {
        public override string Position  => "Pilot"; //get
        public Pilot(string name, string surname, string gender, DateOnly birthDate) : base( name, surname, gender, birthDate) {
            
        }
    }
}
