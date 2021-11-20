using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscalculiaHelper
{

    class Lingua
    {
        //Metodo para mudanca de idioma
        public enum Idioma
        {
            PORTUGUES = 0, INGLES = 1
        }
        public static Idioma idioma { get; set; } = Idioma.PORTUGUES;
    }
}
