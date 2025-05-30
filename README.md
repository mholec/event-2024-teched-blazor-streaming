# TechEd 2024 - Streaming demo

Ukázková aplikace pro konferenci TechEd 2024 demonstrující pokročilé možnosti HTTP streamingu v ASP.NET Core pomocí `IAsyncEnumerable`.

## Popis aplikace

Tato aplikace ukazuje, jak implementovat efektivní streamování dat mezi serverem a klientem. Místo čekání na kompletní dataset můžete začít zpracovávat data ihned, jak dorazí ze serveru. 

## Funkčnosti

### DemoBasic - Streaming API
- **Endpoint**: `GET /api/fragments`
- **Technologie**: `IAsyncEnumerable<T>` pro server-side streaming
- Generuje 10 náhodných datových fragmentů pomocí knihovny Bogus
- Každý fragment je odeslán s 1sekundovou prodlevou pro simulaci real-world scénáře
- Automatická serializace do JSON formátu

### DemoAdvanced - Interaktivní webové rozhraní  
- **Endpoint**: `GET /demo`
- **Technologie**: JavaScript Fetch API s ReadableStream
- Progresivní vykreslování dat v reálném čase
- Ukázka zpracování streamovaných dat v prohlížeči
- Vizuální reprezentace příchozích dat pomocí karet

## Technický stack

- **Framework**: ASP.NET Core 8.0
- **Jazyk**: C# s podporou nullable reference types
- **Závislosti**:
  - `Bogus 35.5.1` - generování testovacích dat
  - `Swashbuckle.AspNetCore 6.4.0` - OpenAPI/Swagger dokumentace
  - `Microsoft.AspNetCore.OpenApi 8.0.0` - OpenAPI metadata

## Požadavky

- .NET 8.0 SDK nebo novější
- Libovolný moderní webový prohlížeč (pro advanced demo)
