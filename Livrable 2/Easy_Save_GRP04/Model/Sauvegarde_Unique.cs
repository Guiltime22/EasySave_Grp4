using System;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using static test.Program;


namespace test
{
    class Sauvegarde_Unique
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
                Butter.LG.Create_Log(file, name, src, dest, ts, Taille); //Function to create a log in log file
            }
            DirectoryInfo diSource = new DirectoryInfo(src);
            DirectoryInfo diTarget = new DirectoryInfo(dest);

            foreach (DirectoryInfo diSourceSubDir in diSource.GetDirectories()) //Check the subdirectories
            {
                DirectoryInfo nextTargetSubDir =
                    diTarget.CreateSubdirectory(diSourceSubDir.Name);
                CopyRepertoire(name, Convert.ToString(diSourceSubDir), Convert.ToString(nextTargetSubDir), etat);
            }
            Butter.ST.Creer_Fichier_Etat(name, src, dest, etat); //Function to create a state into the state file for the work
        }
    }
}
