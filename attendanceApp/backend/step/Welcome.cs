namespace attendanceApp
{
    internal class Welcome
    {
		Message messageClass = new Message();

        internal enum EStartState
		{
			Login,
			CreateUser,
		}

        EStartState startState = EStartState.Login;
        internal void Start()
        {   
			bool isChosen = false;

			Console.CursorVisible = false;

			while (!isChosen)
			{
				Console.Clear();
		    	Console.WriteLine(messageClass.attendanceAppName);
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
					Navigate.navigate(Navigate.AppStep.Login);
                    break;
                case EStartState.CreateUser:
					Navigate.navigate(Navigate.AppStep.Create);
                    break;
                default:
                    Start();
                    break;
            }
        }
    }
}