using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    public class CurrencyController : Controller
    {
        public string ConvertCurrency(string currencyIn, string currencyOut, int qty)
        {
            return $@"CurrencyIn: {currencyIn}
CurrencyOut: {currencyOut}
Qty: {qty}";
        }
    }
}