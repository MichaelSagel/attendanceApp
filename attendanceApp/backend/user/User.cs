using System.Diagnostics.CodeAnalysis;

namespace attendanceApp
{
    public class UserProfile
        {
            public required string name { get; set; }
            public required string email { get; set; }
            public required string password { get; set; }
            public const int presentDays = 134; 
            public List<DateTime> visitDates { get; set; } = new List<DateTime>();

                [SetsRequiredMembers]
                public UserProfile(string userName, string userEmail, string userPassword)
                {
                    name = userName;
                    email = userEmail;
                    password = userPassword;
                }
        }
}