using System;
using System.IO;

namespace Activity5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nFile Operations:");
                Console.WriteLine("1. Create file");
                Console.WriteLine("2. Read file");
                Console.WriteLine("3. Copy file");
                Console.WriteLine("4. Delete file");
                Console.WriteLine("5. File info");
                Console.WriteLine("6. Exit");
                Console.Write("Select option: ");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter file name: ");
                        string createFileName = Console.ReadLine();
                        
                        Console.WriteLine("Enter content (type 'END' on a new line to finish):");
                        using (StreamWriter writer = new StreamWriter(createFileName))
                        {
                            string line;
                            while ((line = Console.ReadLine()) != "END")
                            {
                                writer.WriteLine(line);
                            }
                        }
                        Console.WriteLine("File created.");
                        break;
                        
                    case "2":
                        Console.Write("Enter file name: ");
                        string readFileName = Console.ReadLine();
                        
                        if (File.Exists(readFileName))
                        {
                            Console.WriteLine("\n--- File Content ---");
                            using (StreamReader reader = new StreamReader(readFileName))
                            {
                                Console.WriteLine(reader.ReadToEnd());
                            }
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;
                        
                    case "3":
                        Console.Write("Enter source file: ");
                        string sourceFile = Console.ReadLine();
                        
                        Console.Write("Enter destination file: ");
                        string destFile = Console.ReadLine();
                        
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, destFile, true);
                            Console.WriteLine("File copied.");
                        }
                        else
                        {
                            Console.WriteLine("Source file not found.");
                        }
                        break;
                        
                    case "4":
                        Console.Write("Enter file to delete: ");
                        string deleteFile = Console.ReadLine();
                        
                        if (File.Exists(deleteFile))
                        {
                            File.Delete(deleteFile);
                            Console.WriteLine("File deleted.");
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;
                        
                    case "5":
                        Console.Write("Enter file name: ");
                        string infoFile = Console.ReadLine();
                        
                        if (File.Exists(infoFile))
                        {
                            FileInfo fileInfo = new FileInfo(infoFile);
                            Console.WriteLine("\n--- File Information ---");
                            Console.WriteLine($"Name: {fileInfo.Name}");
                            Console.WriteLine($"Size: {fileInfo.Length} bytes");
                            Console.WriteLine($"Created: {fileInfo.CreationTime}");
                            Console.WriteLine($"Modified: {fileInfo.LastWriteTime}");
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;
                        
                    case "6":
                        return;
                        
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
