using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Models
{
    public static class HoundredsMap
    {
        private static string[] Houndreds { get { return new string[] { "zero", "cem", "duzentos ", "trezentos ", "quatrocentos ", "quinhentos ", "seiscentos ", "setecentos ", "oitocentos ", "novecentos " }; } }

        public static string GetFromPosition(int position)
        {
            return Houndreds[position];
        }
    }
}
