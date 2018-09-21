using System;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using DojoPuzze.Application;
using DojoPuzze.Application.Core;
using DojoPuzze.Application.Extensions.Core;
using DojoPuzze.Application.Extensions;

namespace DojoPuzze
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");
            
            var services = new ServiceCollection();
            
            services.AddSingleton<ICashier, Cashier>();
            services.AddSingleton<IMoneyConverter, MoneyConverter>();

            var provider = services.BuildServiceProvider();

            var cashier = provider.GetService<ICashier>();

            cashier.Start();
        }
    }
}
