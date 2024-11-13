# Web API für Textanalyse

## Projektbeschreibung

Dieses Projekt implementiert eine **Microservice Web-API** unter Verwendung des **ASP.NET Core Minimal API**-Ansatzes. Die API bietet verschiedene Funktionen zur Analyse von Texten, wie das Zählen und Überprüfen von Wörtern und Buchstaben in einem String, die Validierung von E-Mail-Adressen, das Erkennen von Base64-kodierten Strings und eine Funktion zur String-zu-Dezimal-Konvertierung.

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