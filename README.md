# Finnhub.Client
## Installation
You can either download the source and compile or use NuGet at http://nuget.org. To install with nuget:
```
dotnet add package Finnhub.Client --version 1.0.0
```

[![.NET](https://github.com/RoyGerritse/Finnhub/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/RoyGerritse/Finnhub/actions/workflows/dotnet.yml)

## Usage
### Crypto Exchanges
```
var client = new FinnhubClient("token");
var result = await client.CryptoExchanges();
```

### Crypto Symbol
```
var client = new FinnhubClient("token");
var result = await client.CryptoSymbol("KRAKEN");
```

### Crypto Candle
```
var client = new FinnhubClient("token");                   
var result = await client.CryptoCandle("symbol", "D", 1572651390, 1575243390);
```
