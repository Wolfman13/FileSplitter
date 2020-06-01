using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static void WriteToFile(List<string> list, int currentFile)
    {
        string outputPath = Environment.CurrentDirectory.ToString() + $"\\Files\\File{currentFile}.txt";
        File.AppendAllLines(outputPath, list);
    }

    public static void Main()
    {
        int currentFile = 1;
        string inputFile = Environment.CurrentDirectory.ToString() + "\\Words.txt";

        if (File.Exists(inputFile))
        {
            List<string> list = new List<string>();

            Console.WriteLine("Reading to list");

            using (StreamReader reader = new StreamReader(inputFile))
            {
                while (reader.ReadLine() != null)
                {
                    list.Add(reader.ReadLine());

                    if (list.Count >= 10000000)
                    {
                        Console.WriteLine("Writing to file.");
                        WriteToFile(list, currentFile);

                        list = new List<string>();
                        currentFile++;
                    }
                }
            }

            Console.WriteLine("Writing to file.");
            WriteToFile(list, currentFile);

            Console.WriteLine($"Finished splitting file.");
        }

        Console.WriteLine("Press any key to continue...");
        _ = Console.ReadKey();
    }
}
