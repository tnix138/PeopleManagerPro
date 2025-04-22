using System;
using System.Collections.Generic;
using PeopleManagerPro.Models;
using PeopleManagerPro.Services;

namespace PeopleManagerPro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = UserService.SeedUsers();
            User currentUser = UserService.Login(users);
            if (currentUser == null)
            {
                Console.WriteLine("Login failed.");
                return;
            }

            List<Person> people = FileService.LoadPeople();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("People Manager");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. List");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. Stats");
                Console.WriteLine("6. Save");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": PersonService.AddPerson(people); break;
                    case "2": PersonService.DisplayPeople(people); break;
                    case "3": PersonService.DeletePerson(people, currentUser.UserRole); break;
                    case "4": PersonService.SearchPeople(people); break;
                    case "5": PersonService.Stats(people); break;
                    case "6": FileService.SavePeople(people); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid."); break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
