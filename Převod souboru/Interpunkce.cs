using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Převod_souboru
{
    class Interpunkce
    {
        private static char[] interpunkce = { '.', '?', '!', ',', ';', ':', '-', '\"', '\'', '/', '(', ')', '[', ']', '{', '}', '<', '>'};
        private static char[] konecVety = { '.', '?', '!' };

        public static bool jeKonecVety(char c)
        {
            if (konecVety.Contains(c))
                return true;
            return false;
        }

        public static bool jeInterpunkce(char c)
        {
            if (interpunkce.Contains(c))
                return true;
            return false;
        }
    }
}
