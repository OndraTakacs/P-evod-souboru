using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Převod_souboru
{
    /// <summary>
    /// Třída pro zpracování interpunkce
    /// </summary>
    class Interpunkce
    {
        public static char[] interpunkce = { '.', '?', '!', ',', ';', ':', '-', '\"', '\'', '/', '(', ')', '[', ']', '{', '}', '<', '>'};
        public static char[] konecVety = { '.', '?', '!' };

        /// <summary>
        /// Jedná se o znak konce věty?
        /// </summary>
        /// <param name="c">Posuzovaný znak</param>
        /// <returns>True pokud se jedná o konec věty</returns>
        public static bool jeKonecVety(char c)
        {
            if (konecVety.Contains(c))
                return true;
            return false;
        }

        /// <summary>
        /// Jedná se o znak interpunkce?
        /// </summary>
        /// <param name="c">Posuzovaný znak</param>
        /// <returns>True pokud se jedná o znak interpunkce</returns>
        public static bool jeInterpunkce(char c)
        {
            if (interpunkce.Contains(c))
                return true;
            return false;
        }
    }
}
