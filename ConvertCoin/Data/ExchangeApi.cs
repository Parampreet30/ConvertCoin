using ConvertCoin.Data;

using System.Runtime;
using System.Text.Json;

public class ExchangeApi
{
    static readonly string BaseAddress = "https://v6.exchangerate-api.com/";
    static readonly string Url = $"{BaseAddress}v6/a5096e48afea8a20f5ec260f/latest/CAD";

    static HttpClient client;

    private static async Task<HttpClient> GetClient()
    {
        if (client != null)
            return client;

        client = new HttpClient();
        return client;

    }

    public static async Task<IEnumerable<ExchangeRateResponse>> GetRate()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return new List<ExchangeRateResponse>();

        var client = await GetClient();
    string result = await client.GetStringAsync($"{Url}");

    return JsonSerializer.Deserialize<List<ExchangeRateResponse>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });     
    }
    

}