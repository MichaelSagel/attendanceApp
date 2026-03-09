using System.Globalization;

namespace attendanceApp
{
    internal class Date
    {
        internal static void markDayAsAttendance(DateTime date)
            {
                if (Session.CurrentUser!.visitDates.Contains(date))
                {
                    Console.Clear();
                    Console.WriteLine("Dieses Datum wurde bereits hinzugefügt");
                    Task.Delay(4000).Wait();
					Navigate.navigate(Navigate.AppStep.MainMenu);
                }
                else
                {
                    Session.CurrentUser!.visitDates.Add(date);
                    Console.WriteLine("Datum hinzugefügt");
                    Task.Delay(4000).Wait();
					Navigate.navigate(Navigate.AppStep.MainMenu);
                }
            }

        internal static DateTime? ParseDate(string input)
        {
            return DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) 
                ? date 
                : null;
        }
    }
}