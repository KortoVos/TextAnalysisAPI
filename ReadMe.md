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


# Web API für Textanalyse

Dieses Projekt stellt eine Web-API zur Verfügung, die verschiedene Textanalyse-Funktionen bereitstellt. Die API ist unter dem Port `3000` verfügbar und umfasst Funktionen wie das Zählen von Wörtern und Buchstaben, die Validierung von E-Mail-Adressen, das Überprüfen von Base64-codierten Strings und die Konvertierung von Strings in Dezimalwerte.

## Endpunkte und cURL-Beispiele

### 1. **Wörter zählen**
Zählt das Vorkommen von einem oder mehreren Wörtern in einem String.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/count-words -H "Content-Type: application/json" -d "{\"input\":\"Der Hund läuft im Park.\", \"words\":[\"Hund\", \"Park\"]}"
```

### 2. **Prüfen, ob ein Wort enthalten ist**
Überprüft, ob ein oder mehrere Wörter in einem String enthalten sind.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/contains-words -H "Content-Type: application/json" -d "{\"input\":\"Der Hund läuft im Park.\", \"words\":[\"Hund\", \"Auto\"]}"
```

### 3. **Buchstaben zählen**
Zählt das Vorkommen von bestimmten Buchstaben in einem String.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/count-letters -H "Content-Type: application/json" -d "{\"input\":\"Der Hund läuft im Park.\", \"letters\":[\"H\", \"P\"]}"
```

### 4. **Prüfen, ob ein Buchstabe enthalten ist**
Überprüft, ob ein oder mehrere Buchstaben im String enthalten sind.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/contains-letters -H "Content-Type: application/json" -d "{\"input\":\"Der Hund läuft im Park.\", \"letters\":[\"H\", \"X\"]}"
```

### 5. **Überprüfen, ob ein String Base64-kodiert ist**
Überprüft, ob der übergebene String ein gültiger Base64-codierter String ist.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/is-base64 -H "Content-Type: application/json" -d "{\"input\":\"SGVsbG8gd29ybGQh\"}"
```

### 6. **Überprüfen, ob eine E-Mail-Adresse valide ist**
Überprüft, ob die übergebene E-Mail-Adresse ein gültiges Format hat.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/is-email -H "Content-Type: application/json" -d "{\"input\":\"test@example.com\"}"
```

### 7. **String zu Dezimal konvertieren**
Konvertiert einen String in einen Dezimalwert.

**Anfrage:**
```bash
curl -X POST http://localhost:3000/api/text/convert-to-decimal -H "Content-Type: application/json" -d "{\"input\":\"1500,3025\"}"
```

## Erklärung:
- **curl**: Ein Kommandozeilen-Tool, das HTTP-Anfragen senden kann.
- **-X POST**: Gibt an, dass es sich um eine POST-Anfrage handelt.
- **-H "Content-Type: application/json"**: Setzt den Header, um anzugeben, dass die Anfrage im JSON-Format gesendet wird.
- **-d "{\"input\":\"wert\"}"**: Der Body der Anfrage, in dem die Eingabedaten im JSON-Format übergeben werden.

Diese Anfragen kannst du direkt in der CMD oder einem Terminal ausführen, um die API-Endpunkte zu testen.
