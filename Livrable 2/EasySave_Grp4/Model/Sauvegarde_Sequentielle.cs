using System;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using static test.Program;

namespace test
{
    class Sauvegarde_Sequentielle
    {
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
                                Stopwatch stopWatch = new Stopwatch(); //Instance the Timer
                                Stopwatch.StartNew(); //Reset the Timer
                                stopWatch.Start(); //Begin the Timer
                                int tf = Convert.ToInt32(sourceFiles[source].Length);
                                int Taille = tf;
                                stopWatch.Stop(); //Stop the Timer
                                TimeSpan ts = stopWatch.Elapsed;
                                Butter.LG.Create_Log(sourceFiles[source], name, sourcePath, destinationPath, ts, Taille); //Function to create a log in log file

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