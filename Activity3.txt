using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Activity3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "students.txt";

            while (true)
            {
                Console.WriteLine("\nStudent Records:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Show highest score");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter student score: ");
                        int score;
                        while (!int.TryParse(Console.ReadLine(), out score))
                        {
                            Console.Write("Invalid score. Enter a number: ");
                        }

                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.WriteLine($"{name},{score}");
                        }
                        Console.WriteLine("Student added.");
                        break;

                    case "2":
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("No records found.");
                            break;
                        }

                        Console.WriteLine("\n--- Student Records ---");
                        string[] lines = File.ReadAllLines(filePath);
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(',');
                            Console.WriteLine($"{parts[0]}: {parts[1]}");
                        }
                        break;

                    case "3":
                        if (!File.Exists(filePath))
                        {
                            Console.WriteLine("No records found.");
                            break;
                        }

                        List<(string Name, int Score)> students = new List<(string, int)>();
                        foreach (string line in File.ReadAllLines(filePath))
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 2 && int.TryParse(parts[1], out int studentScore))
                            {
                                students.Add((parts[0], studentScore));
                            }
                        }

                        if (students.Count > 0)
                        {
                            var highestScorer = students.OrderByDescending(s => s.Score).First();
                            Console.WriteLine($"\nHighest score: {highestScorer.Name} with {highestScorer.Score} points");
                        }
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
