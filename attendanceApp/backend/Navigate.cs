using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceApp
{

	public class Navigate
	{
		Message messageClass = new Message();
		Welcome welcomeClass = new Welcome();
		public enum AppStep
		{
			Start,
			LogIn,
			Create,
			SendPassword
		}

		public void navigate(AppStep step)

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
				case AppStep.SendPassword:
					// SendPassword
					break;
			}
		}
	}
}
