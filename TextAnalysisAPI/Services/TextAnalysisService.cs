using System.Text.RegularExpressions;

namespace TextAnalysisAPI.Services
{
    public class TextAnalysisService
    {
        // Zählen von einem oder mehreren Wörtern in einem String.
        public int CountWords(string input, string[] words)
        {
            int count = 0;
            foreach (var word in words)
            {
                // \b: Wortgrenzen, um sicherzustellen, dass nur ganze Wörter gezählt werden
                // Regex.Escape(word): Escaped Sonderzeichen im Wort, um Missverständnisse im Muster zu vermeiden
                // RegexOptions.IgnoreCase: Groß-/Kleinschreibung ignorieren
                count += Regex.Matches(input, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase).Count;
            }
            return count;
        }

        // Überprüfen, ob ein oder mehrere Wörter in einem String enthalten ist/sind.
        public bool ContainsWords(string input, string[] words)
        {
            foreach (var word in words)
            {
                // \b: Wortgrenzen, um sicherzustellen, dass nur ganze Wörter gefunden werden
                // Regex.Escape(word): Escaped Sonderzeichen im Wort
                if (Regex.IsMatch(input, $@"\b{Regex.Escape(word)}\b", RegexOptions.IgnoreCase))
                    return true;
            }
            return false;
        }

        // Zählen von einem oder mehreren Buchstaben in einem String.
        public int CountLetters(string input, char[] letters)
        {
            int count = 0;
            foreach (var letter in letters)
            {
                count += input.Count(c => char.ToLower(c) == char.ToLower(letter));
            }
            return count;
        }

        // Überprüfen, ob ein oder mehrere Buchstaben in einem String enthalten ist/sind.
        public bool ContainsLetters(string input, char[] letters)
        {
            foreach (var letter in letters)
            {
                if (input.IndexOf(letter, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }

        // Überprüfen, ob ein String Base64-kodiert ist.
        public bool IsBase64String(string input)
        {
            Span<byte> buffer = new Span<byte>(new byte[input.Length]);
            return Convert.TryFromBase64String(input, buffer, out _);
        }

        // Überprüfen, ob ein String eine valide E-Mail Adresse ist 
        // Sehr verinfacht. Sollte nur genutzt werden um ein erstes Feedback zu geben ob sie ausversehen einen Fehler gemacht haben.
        public bool IsValidEmail(string input)
        {
            // ^[^@\s]+: Mindestens ein Zeichen, das weder @ noch ein Leerzeichen ist, am Anfang
            // @: Das @-Symbol als Trennzeichen für den lokalen und den Domänenteil
            // [^@\s]+\.[^@\s]+$: Mindestens ein Zeichen für den Domänenteil vor und nach dem Punkt, der das Ende markiert
            // RegexOptions.IgnoreCase: Groß-/Kleinschreibung wird ignoriert
            return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }

        // Eingabe Text als Decimal zurück geben
        public string ConvertStringToDecimal(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "0";  

            // Alle erlaubten zeichen entfernen
            string allowedCharacters = "m_ '";
            string sanitizedInput = new string(input.Where(c => !allowedCharacters.Contains(c) ).ToArray());

            // Jeden Punkt mit Komma ersetzen
            sanitizedInput = sanitizedInput.Replace('.', ',');

            // Nur das Letzte Komma beibehalten
            int lastDotIndex = sanitizedInput.LastIndexOf(',');
            if (lastDotIndex != -1)
            {
                var firstPart = sanitizedInput.Substring(0, lastDotIndex ).Replace(",", "");
                var secondPart = sanitizedInput.Substring(lastDotIndex );

                sanitizedInput = firstPart + secondPart;

            }

            // Wenn Parsen fehlschlägt ist ein nicht erlaubtes Zeichen enthalten
            if (double.TryParse(sanitizedInput, out double result))
            {
                // Hier wird nicht das result zurückgegeben, da die Information wie viele 0en hinter dem Komma stehen beim Parsen, verloren gegangen ist
                return sanitizedInput;
            }

            return "0";  // Return "0"  Wenn Parsen fehlschlägt
        }
    }
}
