using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave_Grp4.ModelView
{
    class CL_Gestion 
    {
       public void Modifier_Travail(string name, string Source_File, string Destination_File, string type_save)
        {
            VM_Factory.GT.Modifier_Travail(name, Source_File, Destination_File, type_save);
        }
        public void Supprimer_Travail(string name)
        {
            VM_Factory.GT.Supprimer_Travail(name);
        }
    }
}
