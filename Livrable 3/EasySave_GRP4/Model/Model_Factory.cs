using System;
using System.IO;
//using Newtonsoft.Json;

namespace EasySave_GRP4.Model
{
    class Model_Factory
    {
        public class JFile_parametres
        {
            public string Langue { get; set; }
            public string Cryptage { get; set; }
            public string Metier { get; set; }
            public string Prioritaire { get; set; }
            public string Taille { get; set; }

        }
       
        public class Butter
        {
            public static string path = @"..\..\..\Config\Travaux_Sauvegarde\"; //Folder where the works are
            public static int v;
            static public Langue LGUE = new Langue(); // Instance to use class Langue
            static public States ST = new States(); // Instance to use class States
            static public Log LG = new Log(); // Instance to use class Log
            static public Sauvegarde_Differentiel SVS = new Sauvegarde_Differentiel(); // Instance to use class Sauvegarde Sequentielle
            static public Sauvegarde_Unique SVU = new Sauvegarde_Unique(); // Instance to use class Sauvegarde Sequentielle
            //static public JFile_p JP = new JFile_p();
        }

        
    }
}