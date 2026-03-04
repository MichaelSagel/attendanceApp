using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceApp
{
	public class Navigate
	{
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
					Console.WriteLine("Präsenztage 25-4 App");
					Console.WriteLine("\nEinlogen oder neuen Benutzer erstellen?");
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
