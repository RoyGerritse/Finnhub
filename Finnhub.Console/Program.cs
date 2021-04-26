using System;
using Finnhub.Client;

namespace Finnhub.Console
{    
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new FinnhubClient();
            client.Test();
        }
    }
}
