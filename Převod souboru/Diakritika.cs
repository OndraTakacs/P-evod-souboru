using System;
using System.Collections.Generic;
using System.Linq;

namespace Převod_souboru
{
    /// <summary>
    /// Třída pro zpracování diakritiky
    /// </summary>
    class Diakritika
    {
        public static char[] pismena
            = {'á', 'ä', 'č', 'ď', 'é', 'ě', 'í', 'ľ', 'ĺ', 'ň',
                'ó', 'ö', 'ő', 'ô', 'ř', 'ŕ', 'š', 'ť', 'ú', 'ů', 'ü', 'ű', 'ý',
                'ž', 'Á', 'Ä', 'Č', 'Ď', 'É', 'Ě', 'Í', 'Ľ', 'Ĺ', 'Ň', 'Ó', 'Ö',
                'Ő', 'Ô', 'Ř', 'Ŕ', 'Š', 'Ť', 'Ú', 'Ů', 'Ü', 'Ű', 'Ý', 'Ž'};


        /// <summary>
        /// Má daný znak diakritiku?
        /// </summary>
        /// <param name="c">Posuzovaný znak</param>
        /// <returns>True pokud znak má diakritiku</returns>
        public static bool maDiakritiku(char c)
        {
            if (pismena.Contains(c))
                return true;
            return false;
        }
    }
}
