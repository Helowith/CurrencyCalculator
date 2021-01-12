using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyCalculatorAPI.JSON
{
    public static class Serialize
    {
        public static string ToJson(this CurrencyCalculatorApiJson[] self) => JsonConvert.SerializeObject(self, CurrencyCalculatorAPI.JSON.Converter.Settings);
    }
}
