namespace Airport.Classes
{
    public class PlaneHelper
    {
        public static Plane findById(List<Plane> planes)
        {
            while (true)
            {
                Plane.showPlanes(planes);
                Console.Write("Unesite jedan od postojecih IDieva: ");
                string wanted_id = Console.ReadLine();
                foreach (Plane plane in planes)
                {
                    if (plane.getID() == wanted_id)
                    {
                        return plane;
                    }
                }
                Console.WriteLine();
            }
        }

        public static List<Plane> findByName(List<Plane> planes)
        {
            bool loop = true;
            List<Plane> wanted_names = new List<Plane>();
            while (loop)
            {
                Plane.showPlanes(planes);
                Console.Write("Unesite jedan od postojecih naziva letova: ");
                wanted_names = new List<Plane>();
                string wanted_name = Console.ReadLine();
                foreach (Plane plane in planes)
                {
                    if (plane.Name == wanted_name)
                    {
                        wanted_names.Add(plane);
                        loop = false;
                    }
                }
                Console.WriteLine();
            }
            return wanted_names;
        }
    }
}
