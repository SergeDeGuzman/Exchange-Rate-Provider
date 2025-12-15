using ExchangeRateProvider.Api.Models;
using System.Text.Json;

public class CnbExchangeRateProvider
{
    private readonly HttpClient _httpClient;
    private const string CnbApiBaseUrl = "https://api.cnb.cz"; 

    public CnbExchangeRateProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(CnbApiBaseUrl);
    }

        public async Task<DailyExchangeRates> GetDailyRatesAsync()
    {
        var response = await _httpClient.GetAsync("cnbapi/exrates/daily"); 

        // Error Handling: Throws an exception on HTTP failure 
        response.EnsureSuccessStatusCode(); 

        var jsonStream = await response.Content.ReadAsStreamAsync();

        var rates = await JsonSerializer.DeserializeAsync<DailyExchangeRates>(jsonStream);

        return rates ?? new DailyExchangeRates();
    }

    }