using System;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;

namespace test
{
    public class JFile
    {
        public string name { get; set; }
        public string source_name { get; set; }
        public string dest_name { get; set; }
        public string type_save { get; set; }
    }
    public class Sauvegarde
    {
        public void Travail_Sauvegarde(int choice)
        {
            while (choice > 5)
            {
                Console.WriteLine("Vous avez depassé le seuil de travaux, veuillez réessayer ultérieurement");
            }
            for (int i = 1; i <= choice; i++)
            {
                Console.Clear();
                Console.WriteLine("Veuillez saisir le nom du travail");
                string name = Console.ReadLine();

                Console.WriteLine("Veuillez saisir le dossier source");
                string source_name = Console.ReadLine();

                Console.WriteLine("Veuillez saisir le dossier destination");
                string dest_name = Console.ReadLine();

                Console.WriteLine("Veuillez saisir le type de sauvegarde");
                string type_save = Console.ReadLine();

                var jFile = new JFile
                {
                    name = name,
                    source_name = source_name,
                    dest_name = dest_name,
                    type_save = type_save
                };

                string fileName = @"C:\Users\ghile\Desktop\JFile"+i+".json";
                string jsonString = JsonSerializer.Serialize(jFile);
                File.WriteAllText(fileName, jsonString);

                //Console.WriteLine(jsonString);
            }
            

        }
        
        public void CopyRepertoire(string src, string dest)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(src);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + src);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(dest);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(dest, file.Name);
                file.CopyTo(tempPath, false);
            }
            /*
            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(dest, subdir.Name);
                    CopyRepertoire(subdir.FullName, tempPath, copySubDirs);
                }
            }
            */
        }
    }
}
