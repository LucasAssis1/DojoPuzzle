using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Models
{
    public static class UnitsMap
    {
        private static string[] Units { get { return new string[] { "zero", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" }; } }

        public static string GetFromPosition(int position)
        {
            return Units[position];
        }
    }
}
