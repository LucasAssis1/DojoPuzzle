using System;
using System.Globalization;
using System.Threading;

namespace DojoPuzze
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

            decimal value = RequestMoneyValue();
            string writtenValue = ConvertNumbersToWords(value);

            Console.WriteLine(writtenValue);
            Console.ReadKey();
        }

        public static string ConvertNumbersToWords(decimal value)
        {
            int intValue = (int) Math.Floor(value);

            int cents = GetCents(value); 

            Console.WriteLine("valor inteiro: " +  intValue);

            if (intValue == 0)
                return "zero";

            if (intValue < 0)
                return "menos " + ConvertNumbersToWords(Math.Abs(intValue));

            string words = "";

            if ((intValue / 1000000) > 0)
            {
                words += ConvertNumbersToWords(intValue / 1000000) + " milhão ";
                intValue %= 1000000;
            }

            if ((intValue / 1000) > 0)
            {
                words += ConvertNumbersToWords(intValue / 1000) + " mil ";
                intValue %= 1000;
            }

            if ((intValue / 100) > 0)
            {
                var houndredsMap = new[] { "zero", "cem", "duzentos ", "trezentos ", "quatrocentos ", "quinhentos ", "seiscentos ", "setecentos ", "oitocentos ", "novecentos " };

                string houndredsWord = houndredsMap[intValue / 100];
                intValue %= 100;
                if (intValue > 0 && houndredsWord == "cem")
                    houndredsWord = " cento ";
                
                words += houndredsWord;

            }

            if (intValue > 0)
            {
                if (words != "")
                    words += "e ";

                var unitsMap = new[] { "zero", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
                var tensMap = new[] { "zero", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };

                if (intValue < 20)
                    words += unitsMap[intValue];
                else
                {
                    words += tensMap[intValue / 10];
                    if ((intValue % 10) > 0)
                        words += " e " + unitsMap[intValue % 10];
                }
            }

            return words;
        }

        private static int GetCents(decimal number)
        {
            var cents = number.ToString().Split(",");
            if(cents.Length > 1)
                return Convert.ToInt32(cents[1]);
            return 0;
        }

        private static decimal RequestMoneyValue()
        {
            bool valid = false;

            Console.Write("Insira um valor em dinheiro: R$");
            var value = Console.ReadLine();
            decimal money = 0;
            while(!valid)
            {
                try
                {
                    money = ConvertToMonetary(value);
                    Console.WriteLine("valor inserido: " + money);
                    Console.ReadKey();
                    valid = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.Write("O valor inserido não parece ser um valor em dinheiro \n" +
                                        "Por favor insira um valor válido (sem letras): R$");
                    value = Console.ReadLine();
                }
            }
            return money;
        }

        private static decimal ConvertToMonetary(string value)
        {
            decimal money = Convert.ToDecimal(value);
            return Math.Round(money, 2);
        }
    }
}
