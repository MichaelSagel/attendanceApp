namespace attendanceApp {
    internal class MainMenu
    {
		Message messageClass = new Message();
		AddAttendaceDay addAttendaceDayClass = new AddAttendaceDay();
        internal enum EMainMenuState
		{
            MarkTodayAsAttendance,
			MarkDifferentDayAsAttendance,
			CheckStatusAttendancedDays,
		}
        EMainMenuState mainMenuState = EMainMenuState.MarkTodayAsAttendance;

        internal void UserMenu()
        {
            if(Session.CurrentUser is null)
            {
                Console.WriteLine("Error");
            }
		    Console.WriteLine(messageClass.attendanceAppName);
            Console.WriteLine(Session.CurrentUser!.name);
			bool menuActive  = true;

			Console.CursorVisible = false;

			while (menuActive )
			{
				Console.Clear();
		    	Console.WriteLine(messageClass.attendanceAppName);
				Console.WriteLine("\nWas möchten Sie tun?");
				Console.WriteLine($"{(mainMenuState == EMainMenuState.MarkTodayAsAttendance ? "\x1b[4mHeute als besucht markieren\x1b[0m" : "Heute als besucht markieren")}    " +
					$"{(mainMenuState == EMainMenuState.MarkDifferentDayAsAttendance ? "\x1b[4mEinen anderen Tag als Anwesenheitstag markieren\x1b[0m" : "Einen anderen Tag als Anwesenheitstag markieren")}   " +
					$"{(mainMenuState == EMainMenuState.CheckStatusAttendancedDays ? "\x1b[4mAnwesenheitstage anzeigen\x1b[0m" : "Anwesenheitstage anzeigen")}");

				ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if ((int)mainMenuState > 0) mainMenuState--;
                        break;

                    case ConsoleKey.RightArrow:
                        int maxIndex = Enum.GetValues<EMainMenuState>().Length - 1;

                        if ((int)mainMenuState < maxIndex)
                        {
                            mainMenuState++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        menuActive = false;
                        break;
                }

			};
            
            switch(mainMenuState)
            {
                case EMainMenuState.MarkTodayAsAttendance:
					Date.markDayAsAttendance(DateTime.Today);
                    break;
                case EMainMenuState.MarkDifferentDayAsAttendance:
					addAttendaceDayClass.addAttendaceDay();
                    break;
                case EMainMenuState.CheckStatusAttendancedDays:
                    Console.Clear();
                    Console.WriteLine(messageClass.attendanceAppName);
                    Console.WriteLine($"{Session.CurrentUser.name} sie müssen " +
                    $"noch {Session.CurrentUser.presentDays - Session.CurrentUser.visitDates.Count} Tage Präsenztraining vor Ort absolvieren.");
                    Console.WriteLine("\nTage, an denen Sie das Büro besucht haben:");
                    Session.CurrentUser.visitDates.ForEach(d => Console.WriteLine(d.ToString("dd.MM.yyyy")));
                    Console.WriteLine($"{Session.CurrentUser.name} sie müssen " +
                    $"noch {Session.CurrentUser.presentDays - Session.CurrentUser.visitDates.Count} Tage Präsenztraining vor Ort absolvieren.");
                    break;
                default:
                    UserMenu();
                    break;
            }
        }

    }
}