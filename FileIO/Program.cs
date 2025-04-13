using System;

namespace FileIO
{
    class Program
    {
        static void Main()
        {
            Start(); 
        }

        static void Start()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine(); 
            string filename = name + ".txt"; 

            if (File.Exists(filename)) 
            {
                Console.WriteLine($"Nice to see you again, {name}!");
                Person existingPerson = ReadPerson(filename); 
                DisplayPerson(existingPerson); 
            }
            else
            {
                Console.WriteLine($"Welcome {name}!");
                Person newPerson = ReadPerson(); 
                WritePerson(newPerson, filename); 
            }
        }

        static Person ReadPerson()
        {
            Person person = new Person(); 
            
            Console.Write("Enter your city: ");
            person.City = Console.ReadLine(); 

            Console.Write("Enter your age: ");
            person.Age = int.Parse(Console.ReadLine()); 

            return person; 
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine("--- Person Information ---");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"City: {p.City}");
            Console.WriteLine($"Age: {p.Age}");
            Console.WriteLine("--------------------------");
        }

        static void WritePerson(Person p, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(p.Name); 
                writer.WriteLine(p.City); 
                writer.WriteLine(p.Age); 
            }
            Console.WriteLine("Data saved successfully!");
        }

        static Person ReadPerson(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                Person person = new Person(); 
                person.Name = reader.ReadLine(); 
                person.City = reader.ReadLine(); 
                person.Age = int.Parse(reader.ReadLine()); 
                return person; 
            }
        }
    }
}
