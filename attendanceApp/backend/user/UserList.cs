namespace attendanceApp
{
    internal class UserList
    {
        internal Dictionary<string, UserProfile> userList = new Dictionary<string, UserProfile>(StringComparer.OrdinalIgnoreCase)
        {
            { 
                "test@email.com", 
                new UserProfile("testName", "test@email.com", "securePassword123") 
            }
        };
    }
}