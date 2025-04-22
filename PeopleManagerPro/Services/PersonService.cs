
using System;
using System.Collections.Generic;
using System.Linq;
using PeopleManagerPro.Models;

namespace PeopleManagerPro.Services
{
    public static class PersonService
    {
        public static void AddPerson(List<Person> people)
        {
            Console.Write("First name: ");
            string fn = Console.ReadLine();
            Console.Write("Last name: ");
            string ln = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            people.Add(new Person { FirstName = fn, LastName = ln, Email = email, Phone = phone });
            Logger.Log($"Person added: {fn} {ln}");
            Console.WriteLine("Person added.");
        }

        public static void DisplayPeople(List<Person> people)
        {
            if (!people.Any())
            {
                Console.WriteLine("No records.");
                return;
            }

            string line = "+-----+---------------+---------------+-------------------------+---------------+--------------------+";
            string header = "| No. | First Name    | Last Name     | Email                   | Phone         | Registered         |";
            Console.WriteLine(line);
            Console.WriteLine(header);
            Console.WriteLine(line);

            for (int i = 0; i < people.Count; i++)
            {
                var p = people[i];
                Console.WriteLine(
                    $"| {i + 1,-3} | {p.FirstName,-13} | {p.LastName,-13} | {p.Email,-23} | {p.Phone,-13} | {p.CreatedAt:yyyy-MM-dd HH:mm,-18} |"
                );
            }

            Console.WriteLine(line);
        }

        public static void DeletePerson(List<Person> people, Role role)
        {
            if (role != Role.Admin)
            {
                Console.WriteLine("Only admin can delete.");
                return;
            }

            DisplayPeople(people);
            Console.Write("Enter index to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= people.Count)
            {
                Logger.Log($"Deleted: {people[index - 1].FirstName} {people[index - 1].LastName}");
                people.RemoveAt(index - 1);
                Console.WriteLine("Deleted.");
            }
        }

        public static void SearchPeople(List<Person> people)
        {
            Console.Write("Search term: ");
            var term = Console.ReadLine().ToLower();
            var results = people.Where(p =>
                p.FirstName.ToLower().Contains(term) ||
                p.LastName.ToLower().Contains(term) ||
                p.Email.ToLower().Contains(term)).ToList();

            foreach (var p in results)
                Console.WriteLine($"{p.FirstName} {p.LastName}, Email: {p.Email}, Phone: {p.Phone}");
        }

        public static void Stats(List<Person> people)
        {
            Console.WriteLine($"Total: {people.Count}");
            if (people.Count > 0)
            {
                var last = people.OrderByDescending(p => p.CreatedAt).First();
                Console.WriteLine($"Last added: {last.FirstName} {last.LastName} at {last.CreatedAt}");
            }
        }
    }
}
