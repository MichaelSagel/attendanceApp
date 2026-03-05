namespace attendanceApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Navigate navigateClass = new Navigate();
			navigateClass.navigate(Navigate.AppStep.Start);
		}
	}
}
