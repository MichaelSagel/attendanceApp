namespace attendanceApp
{
    public class Welcome
    {
		Message messageClass = new Message();

        public enum EStartState
		{
            None,
			Login,
			CreateUser,
		}

        EStartState startState = EStartState.None;
        public void Start()
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
                    Console.WriteLine("Login");
                    break;
                case EStartState.CreateUser:
                    Console.WriteLine("CreateUser");
                    break;
                default:
                    Start();
                    break;
            }
        }
    }
}