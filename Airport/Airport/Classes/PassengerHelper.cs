namespace Airport.Classes
{
    public static class PassengerHelper
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;
            else if (password.Length < 8)
                return false;

            var trimmePassword = password.Trim();
            bool hasUpper = false;
            bool hasLower = false;
            bool hasSpec = false;
            bool hasDigit = false;

            foreach (char c in trimmePassword)
            {
                if (char.IsDigit(c)) hasDigit = true;
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                else hasSpec = true;
            }

            return hasUpper && hasLower && hasSpec && hasDigit;
        }

        public static string GetValidEmail()
        {
            string email;
            while (true)
            {
                email = Console.ReadLine();
                if (IsValidEmail(email))
                    return email;

                Console.Write("Email nije valjan! Unesite ponovo: ");
            }
        }

        public static bool EmailExists(string passenger_email, List<Passenger> passengers)
        {
            foreach (var passenger in passengers)
            {
                if (passenger.Email == passenger_email)
                {
                    Console.WriteLine("Uneseni email vec postoji!");
                    return true;
                }
            }
            return false;
        }

        public static string GetValidPass()
        {
            string password;
            while (true)
            {
                password = Console.ReadLine();
                if (IsValidPassword(password))
                    return password;

                Console.Write("Password nije valjan! Unesite ponovo: ");
            }
        }


        public static List<Passenger> PassangerRegistration(List<Passenger> passengers)
        {   Console.Clear();
            Helper.PrintTitle("registracija novog putnika");
            Console.Write("Unesite ime novog putnika ");
            string passenger_name = Helper.IsItString(Console.ReadLine());

            Console.Write("Unesite prezime novog putnika ");
            string passenger_surname = Helper.IsItString(Console.ReadLine());

            Console.Write("Unesite datum rodjenja putnika (YYYY-MM-DD) ");
            DateOnly passenger_birth = Helper.IsValidDate();

            string passenger_email;
            do
            {
                Console.Write("Unesite email ");
                passenger_email = PassengerHelper.GetValidEmail();
            } while (PassengerHelper.EmailExists(passenger_email, passengers));

            Console.Write("Unesite pass (najmanje 8 karaktera, bar 1 veliko slovo, bar 1 broj i bar 1 specijalan znak) ");
            string passenger_password = PassengerHelper.GetValidPass();

            var new_passenger = new Passenger(passenger_name, passenger_surname, passenger_birth, passenger_email, passenger_password);

            passengers.Add(new_passenger);
            Console.Clear();
            return passengers;
        }
    }
}
