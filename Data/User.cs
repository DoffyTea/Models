namespace WebApplication2.Data
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
