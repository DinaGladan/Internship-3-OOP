namespace Airport.Classes
{
    public abstract class CrewMember
    {
        private string Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set;}
        public abstract string Position { get;}
        public string Gender { get; set;}
        public DateOnly BirthDate { get; set; }

        public CrewMember(string name, string surname, string gender, DateOnly birthDate)
        {
            Id = Helper.generateID();
            Name = name;
            Surname = surname;
            Gender = gender;
            BirthDate = birthDate;
        }
        public void printMember()
        {
            Console.WriteLine($"{Id} - {Name} - {Surname} - {Position} - {Gender} - {BirthDate}");
        }
        public string getId()
        {
            return Id;
        }
    }
}
