using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLemur
{
    internal class TextUI
    {
        private static string[] titles = { "Name", "Symbol", "Price", "24h", "7d", "30d", "1y" };
        private CoinReader coinReader;
        
        public TextUI(CoinReader coinReader)
        {
            this.coinReader = coinReader;
        }

        public async Task Start()
        {
            PrintHeadline();
            await PrintCoins();
        }

        private async Task PrintCoins()
        {
            var coins = await coinReader.ProcessCoins();

            foreach (var coin in coins)
            {
                Console.WriteLine(coin);
            }
        }

        private static void PrintHeadline()
        {
            var builder = new StringBuilder();
            foreach (var title in titles)
            {
                if (title != titles.Last())
                {
                    builder.Append(title.PadRight(16));
                }
                else
                {
                    builder.Append(title);
                }
            }

            Console.WriteLine(builder.ToString());
            Console.WriteLine(
                "-------------------------------------------------------------------------------------------------------------");
        }
    }
}
