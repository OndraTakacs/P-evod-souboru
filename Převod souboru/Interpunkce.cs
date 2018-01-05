using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Převod_souboru
{
    class Interpunkce
    {
        public static char[] interpunkce = { '.', '?', '!', ',', ';', ':', '-', '\"', '\'', '/', '(', ')', '[', ']', '{', '}', '<', '>'};
        public static char[] konecVety = { '.', '?', '!' };

        public static bool jeKonecVety(char c)
        {
            if (konecVety.Contains(c))
                return true;
            return false;
        }

        public static bool jjeInterpunkce(char c)
        {
            if (interpunkce.Contains(c))
                return true;
            return false;
        }
    }
}
