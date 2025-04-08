using System;
using System.IO;

namespace Activity2
{
    class Program
    {
        static void Main(string[] args)
        {
            string logFilePath = "application.log";

            while (true)
            {
                Console.WriteLine("\nLogger Options:");
                Console.WriteLine("1. Add log entry");
                Console.WriteLine("2. View log");
                Console.WriteLine("3. Exit");
                Console.Write("Select option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter log message: ");
                        string message = Console.ReadLine();

                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string logEntry = $"[{timestamp}] {message}";

                        using (StreamWriter writer = new StreamWriter(logFilePath, true))
                        {
                            writer.WriteLine(logEntry);
                        }
                        Console.WriteLine("Log entry added.");
                        break;

                    case "2":
                        if (!File.Exists(logFilePath))
                        {
                            Console.WriteLine("Log file does not exist yet.");
                            break;
                        }

                        Console.WriteLine("\n--- Log Content ---");
                        using (StreamReader reader = new StreamReader(logFilePath))
                        {
                            string content = reader.ReadToEnd();
                            Console.WriteLine(content);
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
