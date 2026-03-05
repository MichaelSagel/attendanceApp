namespace attendanceApp
{
    public class UserList
    {
        public Dictionary<string, UserProfile> userList = new Dictionary<string, UserProfile>(StringComparer.OrdinalIgnoreCase);
    }
}