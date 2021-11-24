using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;

namespace test
{
    class Type_Save
    {
        public void CopyRepertoire(string nom_fichier,string src, string dest)
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
                int tf = Convert.ToInt32(file.Length);
                int Taille = tf;
                var Temps = new JProperty("Timestamp", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                var jsonDataWork = File.ReadAllText(LogFile.filepath);
                var File_Var = new LogFile
                {
                    Name = nom_fichier,
                    SourceFilePath = src +"\\"+ file.Name,
                    TargetFilePath = dest +"\\"+ file.Name,
                    Size = Convert.ToString(Taille),
                    Time = Convert.ToString(Temps)
                };
               var workList = JsonConvert.DeserializeObject<List<LogFile>>(jsonDataWork) ?? new List<LogFile>();
             workList.Add(new LogFile()
             {
                 Name = nom_fichier,
                 SourceFilePath = src + "\\" + file.Name,
                 TargetFilePath = dest + "\\" + file.Name,
                 Size = Convert.ToString(Taille),
                 Time = Convert.ToString(Temps)
             });
             string jsonString = JsonConvert.SerializeObject(workList,Formatting.Indented);
             File.WriteAllText(LogFile.filepath, jsonString);
                string tempPath = Path.Combine(dest, file.Name);
                file.CopyTo(tempPath, true);
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
        public void CopyRepertoire_Modifier(string sourcePath, string destinationPath)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
            FileInfo[] sourceFiles = sourceDir.GetFiles();
            for (int source = 0; source < sourceFiles.Length; source++)
            {
                DirectoryInfo destinationDir = new DirectoryInfo(destinationPath);
                FileInfo[] destFiles = destinationDir.GetFiles();
                for (int destination = 0; destination < destFiles.Length; destination++)
                {
                    if (File.Exists(Path.Combine(destinationPath, sourceFiles[source].Name)))
                    {
                        if (sourceFiles[source].Name == destFiles[destination].Name)
                        {
                            if (sourceFiles[source].LastWriteTime > destFiles[destination].LastWriteTime)
                            {
                                sourceFiles[source].CopyTo(Path.Combine(destinationDir.FullName, sourceFiles[source].Name), true);
                            }
                        }
                    }
                    else
                    {
                        sourceFiles[source].CopyTo(Path.Combine(destinationDir.FullName, sourceFiles[source].Name), true);
                    }
                }
            }
        }

    }
}
