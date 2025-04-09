using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Activity4
{
    [Serializable]
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Occupation: {Occupation}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "persons.bin";
            List<Person> people = new List<Person>();

            // Add sample people
            people.Add(new Person { Name = "John Smith", Age = 30, Occupation = "Engineer" });
            people.Add(new Person { Name = "Maria Garcia", Age = 25, Occupation = "Doctor" });
            people.Add(new Person { Name = "Alex Johnson", Age = 40, Occupation = "Teacher" });

            // Write to binary file
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, people);
                }
                Console.WriteLine("Objects written to binary file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to binary file: {ex.Message}");
            }

            // Read from binary file
            try
            {
                List<Person> loadedPeople;
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    loadedPeople = (List<Person>)formatter.Deserialize(fs);
                }

                Console.WriteLine("\nObjects read from binary file:");
                foreach (var person in loadedPeople)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from binary file: {ex.Message}");
            }
        }
    }
}
