using System.Diagnostics.CodeAnalysis;

namespace attendanceApp
{
    internal class UserProfile
        {
            internal required string name { get; set; }
            internal required string email { get; set; }
            internal required string password { get; set; }
            internal readonly int presentDays = 134; 
            internal List<DateTime> visitDates { get; set; } = new List<DateTime>();

                [SetsRequiredMembers]
                internal UserProfile(string userName, string userEmail, string userPassword)
                {
                    name = userName;
                    email = userEmail;
                    password = userPassword;
                }
        }
}