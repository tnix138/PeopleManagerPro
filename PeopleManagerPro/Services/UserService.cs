using System.Collections.Generic;
using System.Linq;
using PeopleManagerPro.Models;

namespace PeopleManagerPro.Services
{
    public static class UserService
    {
        public static List<User> SeedUsers() => new List<User>
        {
            new User { Username = "admin", Password = "1234", UserRole = Role.Admin },
            new User { Username = "guest", Password = "guest", UserRole = Role.Guest }
        };

        public static User Login(List<User> users)
        {
            System.Console.Write("Username: ");
            var username = System.Console.ReadLine();
            System.Console.Write("Password: ");
            var password = System.Console.ReadLine();

            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
