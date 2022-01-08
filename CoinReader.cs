using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoLemur
{
    internal class CoinReader
    {
        private static readonly string baseUri = "https://api.coingecko.com/api/v3/coins/markets?vs_";
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Coin>> ProcessCoins()
        {
            var uri = MakeRequestUri("usd", 10);
            var stream = await client.GetStreamAsync(uri);
            var coins = await JsonSerializer.DeserializeAsync<List<Coin>>(stream);
            return coins;
        }

        private static string MakeRequestUri(string currency, int perPage)
        {
            return $"{baseUri}currency={currency}&order=market_cap_desc&per_page={perPage}&page=1&sparkline=false&price_change_percentage=24h%2C7d%2C30d%2C1y";
        }
    }
}
