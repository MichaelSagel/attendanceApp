namespace attendanceApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Navigate nav = new Navigate();
			nav.navigate(Navigate.AppStep.Start);
		}
	}
}
