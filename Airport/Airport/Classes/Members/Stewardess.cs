namespace Airport.Classes.Members
{
    public class Stewardess : CrewMember
    {
        public override string Position => "Stewardess";
        public Stewardess(string name, string surname, string gender, DateOnly birthDate) : base(name, surname, gender, birthDate)
        {

        }
    }
}
