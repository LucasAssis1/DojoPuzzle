using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Models
{
    public static class TensMap
    {
        private static string[] Tens { get { return new string[] { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" }; } }

        public static string GetFromPosition(int position)
        {
            return Tens[position];
        }
    }
}
