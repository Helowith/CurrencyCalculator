using CurrencyCalculatorAPI.JSON;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CApp.ViewModel
{
    
    public class CurrencyViewModel
    {

        public GetJsonDataFromAPI dataFrom { get; set; } = new GetJsonDataFromAPI();
        /*public IList<string> CurrencyName { get; set; } = new List<string>();
        public IList<double> CurrencyValue { get; set; } = new List<double>();
        public CurrencyViewModel()
        {
            GetThisData();
        }
        public void GetThisData()
        {
            foreach(var data in dataFrom.CurrencyName)
            {
                CurrencyName.Add(data);
            }
            foreach (var data in dataFrom.CurrencyValue)
            {
                CurrencyValue.Add(data);
            }
            */
        
        
    }
}
