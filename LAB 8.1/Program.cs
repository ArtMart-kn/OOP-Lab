using System;
using System.IO;

class Program
{
    static void CopyDirectory(string sourceDir, string targetDir)
    {
        Directory.CreateDirectory(targetDir);

        foreach (var file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(targetDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (var subDir in Directory.GetDirectories(sourceDir))
        {
            string newTargetDir = Path.Combine(targetDir, Path.GetFileName(subDir));
            CopyDirectory(subDir, newTargetDir);
        }
    }
    static void Main()
    {
        string groupNumber = "KN1-B23";
        string lastName = "Martynovskiy";
        string basePath = @"D:\OOP_lab8";
        string groupDir = Path.Combine(basePath, groupNumber);
        string lastNameDir = Path.Combine(basePath, lastName);
        string sourcesDir = Path.Combine(basePath, "Sources");
        string reportsDir = Path.Combine(basePath, "Reports");
        string textsDir = Path.Combine(basePath, "Texts");

        try
        {
            Directory.CreateDirectory(basePath);

            Directory.CreateDirectory(groupDir);
            Directory.CreateDirectory(lastNameDir);
            Directory.CreateDirectory(sourcesDir);
            Directory.CreateDirectory(reportsDir);
            Directory.CreateDirectory(textsDir);

            CopyDirectory(textsDir, Path.Combine(lastNameDir, "Texts"));
            CopyDirectory(sourcesDir, Path.Combine(lastNameDir, "Sources"));
            CopyDirectory(reportsDir, Path.Combine(lastNameDir, "Reports"));

            string newLastNamePath = Path.Combine(groupDir, lastName);
            Directory.Move(lastNameDir, newLastNamePath);

            string dirInfoFile = Path.Combine(textsDir, "dirinfo.txt");
            using (StreamWriter writer = new StreamWriter(dirInfoFile))
            {
                writer.WriteLine("Інформація про каталог Texts:");
                writer.WriteLine($"Повний шлях: {textsDir}");
                writer.WriteLine("Файли:");
                foreach (var file in Directory.GetFiles(textsDir))
                {
                    writer.WriteLine($"- {Path.GetFileName(file)}");
                }
                writer.WriteLine("Підкаталоги:");
                foreach (var dir in Directory.GetDirectories(textsDir))
                {
                    writer.WriteLine($"- {new DirectoryInfo(dir).Name}");
                }
            }

            Console.WriteLine("Операції завершено успішно.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    
}