namespace WebApplication2.Data
{
    public static class ApplicationContext
    {
        public static long index = 0;

        public static List<User> Users { get; private set; } = new()
        {
            new() { Id = index++, Login = "123", Email = "123@123", Age = 123, Password = "123", IsAdmin = true }
        };

        public static User? authorizedUser;

        public static List<Animal> Animals { get; private set; } = new();

        public static void Add(User user)
        {
            Users.Add(user);
        }

        public static void Remove(User user)
        {
            Users.Remove(user);
        }

        public static User? Find(string? login)
        {
            return Users.Find(x => x.Login == login);
        }

        public static void Update(User user)
        {
            User? dbUser = Users.Find(x => x.Login == user.Login);
            if (dbUser != null)
            {
                dbUser.Password = user.Password;
                dbUser.Email = user.Email;
            }
        }

        public static void Add(Animal animal)
        {
            animal.Id = index++;
            Animals.Add(animal);
        }

        public static void Remove(Animal animal)
        {
            Animals.Remove(animal);
        }

        public static Animal? FindAnimal(int id)
        {
            return Animals.Find(a => a.Id == id);
        }
    }
}
