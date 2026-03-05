namespace attendanceApp
{
    public class NewUser
    {
		UserList userListClass = new UserList();
        public void CreateUser()
        {
            Console.WriteLine("Tippen Sie bitte ihre Name ein:");
            string userName2;

            Console.WriteLine("Введите ваше имя:");
            userName2 = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName2))
            {
                Console.WriteLine("Имя не может быть пустым. Пожалуйста, введите имя:");
                userName2 = Console.ReadLine();
            }

                string? userName;
                do
                {
                    Console.WriteLine("Tippen Sie bitte ihre Name ein:");
                    userName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        Console.WriteLine("Fehler: Der Name darf nicht leer sein oder nur aus Leerzeichen bestehen.");
                    }
                } while (string.IsNullOrWhiteSpace(userName));

            //TODO: Finish
            UserProfile newUserProfile = new UserProfile(
                userName,
                "sfdfg",
                "dfgdg");

                bool isAdded = userListClass.userList.TryAdd(newUserProfile.email, newUserProfile);
        }
    }
}