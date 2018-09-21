using System;
using System.Collections.Generic;
using System.Text;

namespace DojoPuzze.Application.Extensions.Core
{
    public interface IMoneyConverter
    {
        decimal ConvertToMonetary(string value);
        string ConvertValueToWords(decimal value);
    }
}
