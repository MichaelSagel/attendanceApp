namespace attendanceApp {
    internal class MainMenu
    {
        internal enum EMainMenuState
		{
            MarkTodayAsAttendance,
			Login,
			CheckStatusAttendancedDays,
		}
        EMainMenuState startState = EMainMenuState.MarkTodayAsAttendance;

        internal void UserMenu(UserProfile user)
        {
            Console.WriteLine(user);
        }
    }
}