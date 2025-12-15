using System.Text.Json.Serialization;

namespace ExchangeRateProvider.Api.Models
{
    public class ExchangeRate
    {
        [JsonPropertyName("validFor")]
        public string ValidFor { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }
        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }
    }    

    public class DailyExchangeRates
    {
        [JsonPropertyName("rates")]
        public List<ExchangeRate> Rates { get; set; } = new List<ExchangeRate>();
    }
}