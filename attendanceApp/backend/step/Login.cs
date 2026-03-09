namespace attendanceApp
{
    internal class Login
    {
		UserList userListClass = new UserList();
		Message messageClass = new Message();

        string? userEmail;
        string? userPassword;

        internal void SignIn()
        {
            do
            {
                Console.Clear();
		        Console.WriteLine(messageClass.attendanceAppName);
                Console.WriteLine("Tippen Sie bitte ihre Email ein:");
                userEmail = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userEmail) || !userListClass.userList.ContainsKey(userEmail));

            do
            {
                Console.Clear();
		        Console.WriteLine(messageClass.attendanceAppName);
                Console.WriteLine("Tippen Sie bitte ihre Password ein:");
                userPassword = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userPassword) || userListClass.userList[userEmail!].password != userPassword);

            Session.CurrentUser = userListClass.userList[userEmail];
			Navigate.navigate(Navigate.AppStep.MainMenu);
        }
    }
}