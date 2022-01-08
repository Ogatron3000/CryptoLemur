using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoLemur
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var coinReader = new CoinReader();
            var ui = new TextUI(coinReader);
            await ui.Start();
        }
    }
}