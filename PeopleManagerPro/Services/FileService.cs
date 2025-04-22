using System;
using System.Collections.Generic;
using System.IO;
using PeopleManagerPro.Models;

namespace PeopleManagerPro.Services
{
    public static class FileService
    {
        public static void SavePeople(List<Person> people)
        {
            using (StreamWriter writer = new StreamWriter("people.txt"))
            {
                foreach (var p in people)
                {
                    writer.WriteLine($"{p.FirstName}|{p.LastName}|{p.Email}|{p.Phone}|{p.CreatedAt}");
                }
            }
            Logger.Log("People saved to file.");
        }

        public static List<Person> LoadPeople()
        {
            var list = new List<Person>();
            if (!File.Exists("people.txt")) return list;

            var lines = File.ReadAllLines("people.txt");
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 5)
                {
                    list.Add(new Person
                    {
                        FirstName = parts[0],
                        LastName = parts[1],
                        Email = parts[2],
                        Phone = parts[3],
                        CreatedAt = DateTime.Parse(parts[4])
                    });
                }
            }
            return list;
        }
    }
}
