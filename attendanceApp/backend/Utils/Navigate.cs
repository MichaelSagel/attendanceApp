namespace attendanceApp
{
	internal class Navigate
	{
		internal enum AppStep
		{
			Start,
			Login,
			Create,
			MainMenu,
		}

		internal static void navigate(AppStep step)
		{
		Login loginClass = new Login();
		Welcome welcomeClass = new Welcome();
		NewUser newUserClass = new NewUser();
        MainMenu mainMenuClass = new MainMenu();
		
			switch (step)
			{
				case AppStep.Start:
					welcomeClass.Start();
					break;
				case AppStep.Login:
                   	loginClass.SignIn();
					break;
				case AppStep.Create:
					newUserClass.CreateUser();
					break;
				case AppStep.MainMenu:
            		mainMenuClass.UserMenu();
					break;
			}
		}
	}
}
