namespace Airport.Classes
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;}

        public BaseEntity() { 
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
        public void UpdateIt()
        {
            LastUpdatedAt = DateTime.Now;
        }
    }
}
