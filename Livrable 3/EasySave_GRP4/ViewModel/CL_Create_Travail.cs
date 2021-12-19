using System;
using System.Collections.Generic;
using System.Text;


namespace EasySave_Grp4.ModelView
{
    class CL_Create_Travail
    {
        public CL_Create_Travail() //constructor

        {
            
        }
        public void Create_Travail(string name, string Source_File, string Destination_File, string type_save)
        {
            VM_Factory.TR.Create_Travail_Sauvegarde(name, Source_File, Destination_File, type_save);
        }
    }
}
