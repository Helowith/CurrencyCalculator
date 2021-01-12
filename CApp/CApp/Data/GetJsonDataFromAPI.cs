using System;
using System.Collections.Generic;
using System.Security;
using System.Text;


namespace CurrencyCalculatorAPI.JSON
{
    public class GetJsonDataFromAPI
    {


        private CurrencyCalculatorApiJson[] CurrencyCalculatorApiJsonVariable { get; set; } 
        public string JsonString { get; set; }
        public IList<string> CurrencyName { get; set; }
        public IList<double> CurrencyValue { get; set; }
        public IList<string> CurrencySignature { get; set; }
        public static bool IsDownloaded { get; set; }
        public GetJsonDataFromAPI()
        {
            GetData();
            GenerateEntaries();
            CurrencyName = new List<string>();
            CurrencyValue = new List<double>();
            CurrencySignature = new List<string>();
            ToLists();
            
            
        }


        private bool GetData()
        {
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    JsonString = webClient.DownloadString("http://api.nbp.pl/api/exchangerates/tables/A/?format=json");
                    return true;
                }
            }
            catch
            {
                return false;
                
            }

        }

        private void GenerateEntaries()
        {
            CurrencyCalculatorApiJsonVariable = CurrencyCalculatorApiJson.FromJson(JsonString);
            
        }
        public void ToLists()
        {
            CurrencyName.Add("polski złoty");
            CurrencyValue.Add(1);
            CurrencySignature.Add("PLN");
            foreach(var value in CurrencyCalculatorApiJsonVariable[0].Rates)
            {
                CurrencyName.Add(value.Currency);
                CurrencyValue.Add(value.Mid);
                CurrencySignature.Add(value.Code);

            }
            

        }
        public double ConvertValueToTargetCurrency(int currencyFromIndex, int currencyToIndex, double valueToConvert)
        {
            return (CurrencyValue[currencyFromIndex] / CurrencyValue[currencyToIndex]) * valueToConvert;
        }
    }

    
}

