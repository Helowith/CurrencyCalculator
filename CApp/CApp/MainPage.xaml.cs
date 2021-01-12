using CApp.ViewModel;
using CurrencyCalculatorAPI.JSON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CApp.ViewModel;
using System.Xml;
using System.Runtime;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;

namespace CApp
{
    
    public partial class MainPage : ContentPage
    {
        
        
        public MainPage()
        {
                InitializeComponent();
        }
       

        private void Button_Clicked(object sender, EventArgs e)
        {
            var currencyModel = new GetJsonDataFromAPI();
            var currencyIndexFrom = CurrencyToConvert.SelectedIndex;
            var currencyIndexTo = CurrencyTarget.SelectedIndex;
            var isDouble = double.TryParse(UserValue.Text, out var parsedValue);
            if(currencyIndexFrom!=(-1) && currencyIndexTo !=(-1) && parsedValue > 0)
            {
                var calculatedValue = currencyModel.ConvertValueToTargetCurrency(currencyIndexFrom, currencyIndexTo, parsedValue);
                var roundedValue = Math.Round(calculatedValue, 2);
                OutCalculatedText.Text = "Przeliczona wartość:";
                OutCalculatedValue.Text = $"{roundedValue} {currencyModel.CurrencySignature[currencyIndexTo]}";
            }
            else if(currencyModel.JsonString==null){
                DisplayAlert("Błąd", "Brak połączenia z internetem", "OK");
            }
            else
            {
                DisplayAlert("Błąd", "Uzupełnij wszystkie pola!", "OK");
                
            }
            
            


        }

        
    }
}
