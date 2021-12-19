using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.Model
{
    class Gestion_Travail
    {

        public void Modifier_Travail(string name, string Source_File, string Destination_File, string type_save)
        {
            string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + name + ".json";
            File.Delete(fileName);
            Butter.CT.Create_Travail_Sauvegarde(name, Source_File, Destination_File, type_save);
        }
        public void Supprimer_Travail(string name)
        {
            string fileName = @"..\..\..\Config\Travaux_Sauvegarde\" + name + ".json";
            File.Delete(fileName);
        }
    }
} 