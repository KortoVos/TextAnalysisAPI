# Web API für Textanalyse


## Funktionen

1. **Zählen von Wörtern** in einem String.
2. **Überprüfen, ob Wörter** in einem String enthalten sind.
3. **Zählen von Buchstaben** in einem String.
4. **Überprüfen, ob Buchstaben** in einem String enthalten sind.
5. **Überprüfen, ob ein String Base64-kodiert** ist.
6. **Überprüfen, ob ein String eine gültige E-Mail-Adresse** ist.
7. **String-zu-Dezimal-Konvertierung**, um verschieden formatierte Zahlenstrings in einen Dezimalwert umzuwandeln.

## Anforderungen

- **.NET 8** oder höher

## Installation

### 1. Klone das Repository

```bash
git clone https://github.com/KortoVos/TextAnalysisAPI.git
cd TextAnalysisAPI
cd TextAnalysisAPI
```

### 2. Abhängigkeiten installieren
Sicher stellen das .NET 8 installiert ist, und Abhängigkeiten installieren:
```bash
dotnet restore
```

NUnit muss installiert sein
```bash
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

BenchmarkDotNet muss installiert sein
```bash
dotnet add package BenchmarkDotNet
```

### 3. Projekt starten
Starten der API mit:
```bash
dotnet run
```

Die API sollte nun unter `https://localhost:3001` oder `http://localhost:3000` laufen.


## Endpunkte und cURL-Beispiele
# Text Analysis API Endpoints Documentation

## Endpoint für countWords

```bash
curl "https://localhost:3001/countWords?input=The%20dog%20runs%20in%20the%20park.&words=dog&words=park"
```

## Endpoint für containsWords

```bash
curl "https://localhost:3001/containsWords?input=The%20dog%20runs%20in%20the%20park.&words=dog&words=cat"
```

## Endpoint für countLetters

```bash
curl "https://localhost:3001/countLetters?input=The%20dog%20runs%20in%20the%20park.&letters=d&letters=o"
```

## Endpoint für containsLetters

```bash
curl "https://localhost:3001/containsLetters?input=The%20dog%20runs%20in%20the%20park.&letters=a&letters=z"
```

## Endpoint für isBase64

```bash
curl "https://localhost:3001/isBase64?input=U29tZSBCYXNlNjQgc3RyaW5n"
```

## Endpoint für isValidEmail

```bash
curl "https://localhost:3001/isValidEmail?input=test@example.com"
```

## Endpoint für convertStringToDecimal

```bash
curl "https://localhost:3001/convertStringToDecimal?input=1_234.56"
```