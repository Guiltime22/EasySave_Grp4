using System;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using static test.Program;

namespace test
{
    class Type_Save
    {
        public void CopyRepertoire(string name, string src, string dest, string etat) //Function to copy the files completly
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
                Butter.LG.Create_Logxml(file, name, src, dest, ts, Taille); //Function to create a log in log file
                Butter.LG.Create_LogJson(file, name, src, dest, ts, Taille); //Function to create a log in log file
            }
            DirectoryInfo diSource = new DirectoryInfo(src);
            DirectoryInfo diTarget = new DirectoryInfo(dest);

            foreach (DirectoryInfo diSourceSubDir in diSource.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    diTarget.CreateSubdirectory(diSourceSubDir.Name);
                CopyRepertoire(name, Convert.ToString(diSourceSubDir), Convert.ToString(nextTargetSubDir), etat);
            }
            Butter.ST.Creer_Fichier_Etat(name, src, dest, etat); //Function to create a state into the state file for the work
            Butter.ST.Creer_Fichier_Etatx(name, src, dest, etat); //Function to create a state into the state file for the work
        }
        public void CopyRepertoire_Modifier(string name, string sourcePath, string destinationPath, string etat)  //Function to copy the files differential
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourcePath); //Get the informations of the directory source
            FileInfo[] sourceFiles = sourceDir.GetFiles(); //Get files from the directory source
            for (int source = 0; source < sourceFiles.Length; source++)
            {
                DirectoryInfo destinationDir = new DirectoryInfo(destinationPath); //Get the informations of the directory destination
                FileInfo[] destFiles = destinationDir.GetFiles(); //Get files from the directory destination
                for (int destination = 0; destination < destFiles.Length; destination++)
                {
                    if (File.Exists(Path.Combine(destinationPath, sourceFiles[source].Name)))
                    {
                        if (sourceFiles[source].Name == destFiles[destination].Name) //Check if the exist in both the directories
                        {
                            if (sourceFiles[source].LastWriteTime > destFiles[destination].LastWriteTime) //Check the WriteTime of the both files 
                            {
                                sourceFiles[source].CopyTo(Path.Combine(destinationDir.FullName, sourceFiles[source].Name), true); //Execute the copy
                                Butter.ST.Creer_Fichier_Etat(name, sourcePath, destinationPath, etat);
                                Butter.ST.Creer_Fichier_Etatx(name, sourcePath, destinationPath, etat);
                                Stopwatch stopWatch = new Stopwatch(); //Instance the Timer
                                Stopwatch.StartNew(); //Reset the Timer
                                stopWatch.Start(); //Begin the Timer
                                int tf = Convert.ToInt32(sourceFiles[source].Length);
                                int Taille = tf;
                                stopWatch.Stop(); //Stop the Timer
                                TimeSpan ts = stopWatch.Elapsed;
                                Butter.LG.Create_Logxml(sourceFiles[source], name, sourcePath, destinationPath, ts, Taille); //Function to create a log in log file
                                Butter.LG.Create_LogJson(sourceFiles[source], name, sourcePath, destinationPath, ts, Taille); //Function to create a log in log file

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