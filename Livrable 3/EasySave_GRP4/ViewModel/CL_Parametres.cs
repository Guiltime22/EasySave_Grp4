using System;
using System.Collections.Generic;
using System.Text;

namespace EasySave_Grp4.ModelView
{
    class CL_Parametres
    {
        public CL_Parametres()
        {

        }
        public void Parametres(string Langue, string type)
        {
            VM_Factory.P.Parametres_Generaux(Langue, type);
        }
    }
}
