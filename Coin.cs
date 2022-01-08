using System.Text.Json.Serialization;

namespace CryptoLemur
{
    internal class Coin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("current_price")]
        public float CurrentPrice { get; set; }

        [JsonPropertyName("price_change_percentage_24h_in_currency")]
        public float ChangeDay { get; set; }

        [JsonPropertyName("price_change_percentage_7d_in_currency")]
        public float ChangeWeek { get; set; }

        [JsonPropertyName("price_change_percentage_30d_in_currency")]
        public float ChangeMonth { get; set; }

        [JsonPropertyName("price_change_percentage_1y_in_currency")]
        public float ChangeYear { get; set; }

        public override string ToString()
        {
            return Name?.PadRight(16)
                + Symbol?.ToUpper().PadRight(16)
                + CurrentPrice.ToString("c").PadRight(16)
                + ChangeDay.ToString(percentageFormat(ChangeDay)).PadRight(16)
                + ChangeWeek.ToString(percentageFormat(ChangeWeek)).PadRight(16)
                + ChangeMonth.ToString(percentageFormat(ChangeMonth)).PadRight(16)
                + ChangeYear.ToString(percentageFormat(ChangeYear));
        }

        private static string percentageFormat(float value)
        {
            return value > 0 ? "+0.00\\%" : "0.00\\%";
        }
    }
}
