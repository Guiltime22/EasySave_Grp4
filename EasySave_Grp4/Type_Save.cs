using System;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;

namespace test
{
    class Type_Save
    {
        private States ST = new States();
        private Log LG = new Log();
        public void CopyRepertoire(string name, string src, string dest, string etat)
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
                Stopwatch stopWatch = new Stopwatch();
                Stopwatch.StartNew();
                stopWatch.Start();
                string tempPath = Path.Combine(dest, file.Name);
                file.CopyTo(tempPath, true);
                int tf = Convert.ToInt32(file.Length);
                int Taille = tf;
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                LG.Create_Log(file, name, src, dest, ts, Taille);
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
            ST.Creer_Fichier_Etat(name, src, dest, etat);
        }
        public void CopyRepertoire_Modifier(string name, string sourcePath, string destinationPath, string etat)
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
                                ST.Creer_Fichier_Etat(name, sourcePath, destinationPath, etat);
                                Stopwatch stopWatch = new Stopwatch();
                                Stopwatch.StartNew();
                                stopWatch.Start();
                                int tf = Convert.ToInt32(sourceFiles[source].Length);
                                int Taille = tf;
                                stopWatch.Stop();
                                TimeSpan ts = stopWatch.Elapsed;
                                LG.Create_Log(sourceFiles[source], name, sourcePath, destinationPath, ts, Taille);

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