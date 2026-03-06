namespace attendanceApp
{
    internal class Welcome
    {
		Message messageClass = new Message();
		NewUser newUserClass = new NewUser();
		Login loginClass = new Login();

        internal enum EStartState
		{
			Login,
			CreateUser,
		}

        EStartState startState = EStartState.Login;
        internal void Start()
        {
		    Console.WriteLine(messageClass.attendanceAppName);
            
			bool isChosen = false;

			Console.CursorVisible = false;

			while (!isChosen)
			{
				Console.Clear();
				Console.WriteLine("\nEinlogen oder neuen Benutzer erstellen?");
				Console.WriteLine($"{(startState == EStartState.Login ? "\x1b[4mEinlogen\x1b[0m" : "Einlogen")}	" +
					$"{(startState == EStartState.CreateUser ? "\x1b[4mRegestrieren\x1b[0m" : "Regestrieren")}");

				ConsoleKey key = Console.ReadKey(true).Key;

				if (key == ConsoleKey.LeftArrow)
				{
					startState = EStartState.Login;
				}
				else if (key == ConsoleKey.RightArrow)
				{
					startState = EStartState.CreateUser;
				}
				else if (key == ConsoleKey.Enter)
				{
					isChosen = true;
				}
			}
            
            switch(startState)
            {
                case EStartState.Login:
                    loginClass.SignIn();
                    break;
                case EStartState.CreateUser:
					newUserClass.CreateUser();
                    break;
                default:
                    Start();
                    break;
            }
        }
    }
}