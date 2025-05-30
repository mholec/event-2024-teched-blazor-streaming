# Streaming Demo - TechEd 2024

Ukázková aplikace pro konferenci TechEd 2024 demonstrující pokročilé možnosti HTTP streamingu v ASP.NET Core pomocí `IAsyncEnumerable`.

## Popis aplikace

Tato aplikace předvádí, jak implementovat efektivní streamování dat mezi serverem a klientem. Místo čekání na kompletní dataset můžete začít zpracovávat data ihned, jak dorazí ze serveru. Ideal pro zpracování velkých datových sad, real-time aktualizace nebo zlepšení uživatelské zkušenosti.

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

## Spuštění aplikace

### 1. Klonování repository
```bash
git clone https://github.com/mholec/event-2024-teched-blazor-streaming.git
cd event-2024-teched-blazor-streaming
```

### 2. Obnovení závislostí
```bash
dotnet restore
```

### 3. Sestavení aplikace
```bash
dotnet build
```

### 4. Spuštění aplikace
```bash
dotnet run
```

Aplikace bude dostupná na `https://localhost:5001` (nebo `http://localhost:5000`)

## Dostupné endpointy

### API Endpoints

#### `GET /api/fragments`
Vrací stream dat ve formátu JSON. Každý fragment obsahuje:
```json
{
  "id": 1,
  "name": "Jméno osoby",
  "title": "Popis nebo titulek"
}
```

**Příklad použití s curl:**
```bash
curl -N http://localhost:5000/api/fragments
```

### Webové rozhraní

#### `GET /demo`
Interaktivní demo stránka, která:
- Načítá data z `/api/fragments` endpoint
- Zobrazuje progresivní načítání dat
- Vykresluje každý datový fragment jako kartu
- Demonstruje real-time zpracování streamovaných dat

## Jak to funguje

### Server-side streaming
```csharp
[HttpGet("api/fragments")]
public async IAsyncEnumerable<DataFragment> GetBasicData()
{
    // Generování dat pomocí Bogus
    var fakeData = fakeGen.Generate(10);

    foreach (var dataFragment in fakeData)
    {
        yield return dataFragment;  // Streamování po jednom fragmentu
        await Task.Delay(1000);     // Simulace zpracování
    }
}
```

### Client-side streaming
```javascript
const response = await fetch('api/fragments');
const reader = response.body.getReader();

while (true) {
    const { done, value } = await reader.read();
    if (done) break;
    
    // Zpracování příchozích dat v reálném čase
    const item = JSON.parse(jsonData);
    renderData(item);
}
```

## Výhody streamingu

1. **Nižší latence** - data se začnou zpracovávat okamžitě
2. **Lepší uživatelská zkušenost** - progresivní načítání obsahu
3. **Efektivní využití paměti** - zpracování dat po částech
4. **Škálovatelnost** - vhodné pro velké datové sady

## Použité design patterns

- **Producer-Consumer pattern** - pomocí `IAsyncEnumerable`
- **Streaming pattern** - progresivní zpracování dat
- **MVC pattern** - separace logiky, view a kontrolerů

## Další vývoj

Tato aplikace slouží jako základ pro:
- Real-time dashboardy
- Progresivní načítání obsahu
- Chat aplikace
- Live aktualizace dat
- Export velkých datových sad

## Autor

Ukázková aplikace pro TechEd 2024
