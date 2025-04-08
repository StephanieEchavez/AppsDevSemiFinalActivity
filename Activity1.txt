using System;
using System.IO;

namespace Activity1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "userInput.txt";

            Console.WriteLine("Enter text to write to the file (type 'exit' on a new line to finish):");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (input.ToLower() == "exit")
                        break;

                    writer.WriteLine(input);
                }
            }

            Console.WriteLine("\nFile saved. Reading the content:");

            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("\nFile Content:\n");
                Console.WriteLine(content);
            }
        }
    }
}
