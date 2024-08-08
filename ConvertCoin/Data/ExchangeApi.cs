using ConvertCoin.Data;

using System.Runtime;
using System.Text.Json;

public class ExchangeApi
{
    static readonly string BaseAddress = "https://v6.exchangerate-api.com/";
    static readonly string Url = $"{BaseAddress}v6/a5096e48afea8a20f5ec260f/latest/";

    static HttpClient client;

    private static async Task<HttpClient> GetClient()
    {
        if (client != null)
            return client;

        client = new HttpClient();
        return client;

    }

    public static async Task<ExchangeRateResponse> GetRate(string CountryCode)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return new ExchangeRateResponse();

        var client = await GetClient();
        string result = await client.GetStringAsync($"{Url}"+CountryCode);

        var elevadoresModels = JsonSerializer.Deserialize<ExchangeRateResponse>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
       


        return JsonSerializer.Deserialize<ExchangeRateResponse>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }


}