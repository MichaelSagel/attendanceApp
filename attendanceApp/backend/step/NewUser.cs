namespace attendanceApp
{
    internal class NewUser
    {
		UserList userListClass = new UserList();
		Message messageClass = new Message();
        internal void CreateUser()
        {
            string? userName;
            string? userEmail;
            string? userPassword;
            do
            {
                Console.Clear();
		        Console.WriteLine(messageClass.attendanceAppName);
                Console.WriteLine("Tippen Sie bitte ihre Name ein:");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("Fehler: Der Name darf nicht leer sein oder nur aus Leerzeichen bestehen.");
                }
            } while (string.IsNullOrWhiteSpace(userName));

            do
            {
                Console.Clear();
		        Console.WriteLine(messageClass.attendanceAppName);
                Console.WriteLine("Tippen Sie bitte ihre Email ein:");
                userEmail = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userEmail))
                {
                    Console.WriteLine("Fehler: Der Email darf nicht leer sein oder nur aus Leerzeichen bestehen.");
                }
            } while (string.IsNullOrWhiteSpace(userEmail));
            
            do
            {
                Console.Clear();
		        Console.WriteLine(messageClass.attendanceAppName);
                Console.WriteLine("Tippen Sie bitte ihre Password ein:");
                userPassword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userPassword))
                {
                    Console.WriteLine("Fehler: Der Password darf nicht leer sein oder nur aus Leerzeichen bestehen.");
                }
            } while (string.IsNullOrWhiteSpace(userPassword));

            UserProfile newUserProfile = new UserProfile(
                userName,
                userEmail,
                userPassword);

            bool isAdded = userListClass.userList.TryAdd(newUserProfile.email, newUserProfile);

            if(!isAdded)
            {
                Console.Clear();
                Console.WriteLine("Ein Benutzer mit dieser E-Mail-Adresse existiert bereits.");
                Task.Delay(4000).Wait();
                CreateUser();
            } else
            {
                Session.CurrentUser = newUserProfile;
				Navigate.navigate(Navigate.AppStep.MainMenu);
            }
        }
    }
}