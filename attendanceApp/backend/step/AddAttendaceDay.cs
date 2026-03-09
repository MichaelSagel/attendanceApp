using System;
using System.Collections.Generic;
using System.Globalization;

namespace attendanceApp
{
    internal class AddAttendaceDay
    {
		Message messageClass = new Message();
        internal void addAttendaceDay()
        {
            Console.Clear();
            Console.WriteLine(messageClass.attendanceAppName);
            Console.WriteLine("\nBitte geben Sie das Datum der Teilnahme im Format TT.MM.JJJJ ein:");
            string inputAttendanceDay = Console.ReadLine();

            if (DateTime.TryParseExact(inputAttendanceDay, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
            {
				Date.markDayAsAttendance(parsedDate);
            }
            else
            {
                Console.WriteLine("Ungültiges Format");
                Task.Delay(4000).Wait();
                addAttendaceDay();
            }

        }
    }
}