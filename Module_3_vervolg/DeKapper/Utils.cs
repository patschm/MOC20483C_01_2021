using System;
using System.Collections.Generic;
using System.Text;

namespace DeKapper
{
    static class Utils
    {
        // Een Extensie
        public static string StripSpaces(this string inp)
        {
            return inp.Replace(' ', '_');
        }
    }
}
