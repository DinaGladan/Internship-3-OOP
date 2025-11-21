namespace Airport.Classes
{
    public class Plane
    {
        private string Id { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int NumberOfFlights { get; set; }

        public Plane(string name, int productionYear, int numberOfFlights)
        {
            Id = Helper.generateID();
            Name = name;
            ProductionYear = productionYear;
            NumberOfFlights = numberOfFlights;
        }

        public void printPlane()
        {
            Console.WriteLine($"{Id} - {Name} - {ProductionYear} - {NumberOfFlights}");
        }

        
    }
   
}
