using System;
using System.Collections.Generic;

namespace Převod_souboru
{
    class Diakritika
    {
        private static SortedSet<char> pismena
            = new SortedSet<char>{'á', 'ä', 'č', 'ď', 'é', 'ě', 'í', 'ľ', 'ĺ', 'ň',
                'ó', 'ö', 'ő', 'ô', 'ř', 'ŕ', 'š', 'ť', 'ú', 'ů', 'ü', 'ű', 'ý',
                'ž', 'Á', 'Ä', 'Č', 'Ď', 'É', 'Ě', 'Í', 'Ľ', 'Ĺ', 'Ň', 'Ó', 'Ö',
                'Ő', 'Ô', 'Ř', 'Ŕ', 'Š', 'Ť', 'Ú', 'Ů', 'Ü', 'Ű', 'Ý', 'Ž'};

        public static bool maDiakritiku(char c)
        {
            if (pismena.Contains(c))
                return true;
            return false;
        }
    }
}
