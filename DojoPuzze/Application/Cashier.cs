using DojoPuzze.Application.Core;
using DojoPuzze.Application.Extensions.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Application
{
    public class Cashier : ICashier
    {
        private readonly IMoneyConverter _moneyConverter;
        public Cashier(IMoneyConverter moneyConverter)
        {
            _moneyConverter = moneyConverter;
        }

        public void Start()
        {
            decimal value = RequestValue();

            string writtenValue = _moneyConverter.ConvertValueToWords(value);

            Console.WriteLine(writtenValue);
            Console.WriteLine("Pressione enter para sair");
            Console.ReadLine();
        }

        private decimal RequestValue()
        {
            Console.Write("Insira um valor em dinheiro (separando centavos por vírgula (\",\") ): R$");
            var value = Console.ReadLine();
            return ValidateInsertedValue(value);
        }

        private decimal ValidateInsertedValue(string value)
        {
            decimal money = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    money = _moneyConverter.ConvertToMonetary(value);
                    Console.WriteLine("valor inserido: " + money);
                    valid = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("O valor inserido não parece ser um valor em dinheiro. \n");
                    RequestValue();
                }
            }
            return money;
        }
    }
}
