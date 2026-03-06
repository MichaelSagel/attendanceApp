namespace attendanceApp
{
	internal class Navigate
	{
		Message messageClass = new Message();
		Welcome welcomeClass = new Welcome();
		internal enum AppStep
		{
			Start,
			LogIn,
			Create,
		}

		internal void navigate(AppStep step)

		{
			switch (step)
			{
				case AppStep.Start:
					Console.WriteLine(messageClass.attendanceAppName);
					welcomeClass.Start();
					break;
				case AppStep.LogIn:
					// LogIn
					break;
				case AppStep.Create:
					// Create
					break;
			}
		}
	}
}
