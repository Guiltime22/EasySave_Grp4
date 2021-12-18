using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Threading;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;


namespace EasySave_GRP4.Model
{
    class Sauvegarde_Unique
    {
        public void CopyRepertoire(string name, string src, string dest, string etat) //Function to copy the files completly
        {
            StreamReader r = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonString = r.ReadToEnd();
            JFile_parametres JP = JsonConvert.DeserializeObject<JFile_parametres>(jsonString);
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
                if (Process.GetProcessesByName(JP.Metier).Length == 0)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    Stopwatch CryptWatch = new Stopwatch();

                    string tempPath = Path.Combine(dest, file.Name);
                    if (file.Extension == "." + JP.Cryptage)
                    {
                        Stopwatch.StartNew();
                        var p = new Process();
                        p.StartInfo.FileName = @"..\..\..\..\CryptoSoft\bin\Debug\netcoreapp3.0\Cryptage_Soft.exe";
                        p.StartInfo.Arguments = $"{file.FullName} {tempPath}";
                        CryptWatch.Start();
                        p.Start();
                        CryptWatch.Stop();
                    }
                    TimeSpan cts = CryptWatch.Elapsed;
                    Stopwatch.StartNew();
                    stopWatch.Start();
                    file.CopyTo(tempPath, true);
                    int tf = Convert.ToInt32(file.Length);
                    int Taille = tf;
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    Butter.LG.Create_Log(file, name, src, dest, ts, cts, Taille); //Function to create a log in log file
                }
                else
                {
                    while (Process.GetProcessesByName(JP.Metier).Length != 0)
                    {
                        MessageBox.Show("Votre logiciel métier est en cours d'éxecution, veuillez le fermer !");
                    }
                }
            }
            DirectoryInfo diSource = new DirectoryInfo(src);
            DirectoryInfo diTarget = new DirectoryInfo(dest);

            foreach (DirectoryInfo diSourceSubDir in diSource.GetDirectories()) //Check the subdirectories
            {
                if (Process.GetProcessesByName(JP.Metier).Length == 0)
                {
                    DirectoryInfo nextTargetSubDir =
                    diTarget.CreateSubdirectory(diSourceSubDir.Name);
                    CopyRepertoire(name, Convert.ToString(diSourceSubDir), Convert.ToString(nextTargetSubDir), etat);
                }
                else
                {
                    while (Process.GetProcessesByName(JP.Metier).Length != 0)
                    {
                        MessageBox.Show("Votre logiciel métier est en cours d'éxecution, veuillez le fermer !");
                    }
                }
            }
            Butter.ST.Creer_Fichier_Etat(name, src, dest, etat); //Function to create a state into the state file for the work
        }
    }
}
