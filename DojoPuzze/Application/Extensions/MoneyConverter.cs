using DojoPuzze.Application.Extensions.Core;
using DojoPuzze.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Application.Extensions
{
    public class MoneyConverter : IMoneyConverter
    {
        public decimal ConvertToMonetary(string value)
        {
            decimal money = Convert.ToDecimal(value);
            return Math.Round(money, 2);
        }

        public string ConvertValueToWords(decimal value)
        {
            var intText = ConvertNumbersToWords(GetInteger(value)) + " reais";
            var centsText = ConvertNumbersToWords(GetCents(value)) + " centavos";
            return intText + " e " + centsText;
        }

        private string ConvertNumbersToWords(int value)
        {
            if (value == 0)
                return "zero";

            if (value < 0)
                return "menos " + ConvertNumbersToWords(Math.Abs(value));

            string words = "";

            if ((value / 1000000) > 0)
            {
                var million = value / 1000000;
                words += ConvertNumbersToWords(million) + (million > 1 ? " milhões " : " milhão ");
                value %= 1000000;
            }

            if ((value / 1000) > 0)
            {
                words += ConvertNumbersToWords(value / 1000) + " mil ";
                value %= 1000;
            }

            if ((value / 100) > 0)
            {

                string houndredsWord = HoundredsMap.GetFromPosition(value / 100);
                value %= 100;
                if (value > 0 && houndredsWord == "cem")
                    houndredsWord = " cento ";

                words += houndredsWord;

            }

            if (value > 0)
            {
                if (words != "")
                    words += "e ";

                if (value < 20)
                    words += UnitsMap.GetFromPosition(value);
                else
                {
                    words += TensMap.GetFromPosition(value / 10);
                    if ((value % 10) > 0)
                        words += " e " + UnitsMap.GetFromPosition(value % 10);
                }
            }

            return words;
        }

        private int GetCents(decimal number)
        {
            var cents = number.ToString().Split(",");
            if (cents.Length > 1)
                return Convert.ToInt32(cents[1]);
            return 0;
        }

        private int GetInteger(decimal number)
        {
            return (int)Math.Floor(number);
        }
    }
}
