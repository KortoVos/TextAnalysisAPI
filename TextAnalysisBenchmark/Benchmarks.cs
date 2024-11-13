using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using TextAnalysisAPI.Services;

public class TextAnalysisBenchmarks
{
    private readonly TextAnalysisService _service = new TextAnalysisService();
    private readonly string _sampleText = "Dies ist ein Beispieltext mit mehreren Wörtern, die wiederholt werden.";

    [Benchmark]
    public void CountWordsBenchmark()
    {
        _service.CountWords(_sampleText, new[] { "Beispieltext", "Wörtern" });
    }

    [Benchmark]
    public void ContainsWordBenchmark()
    {
        _service.ContainsWords(_sampleText, new[] { "Beispieltext" });
    }

    [Benchmark]
    public void CountLettersBenchmark()
    {
        _service.CountLetters(_sampleText, new[] { 'e', 't' });
    }

    [Benchmark]
    public void ContainsLetterBenchmark()
    {
        _service.ContainsLetters(_sampleText, new[] { 'z' });
    }

    [Benchmark]
    public void IsBase64EncodedBenchmark()
    {
        _service.IsBase64String("VGhpcyBpcyBhIHRlc3Qgc3RyaW5nLg==");
    }

    [Benchmark]
    public void IsValidEmailBenchmark()
    {
        _service.IsValidEmail("test@example.com");
    }
}


//| Method | Mean | Error | StdDev | Median |
//| ------------------------- | ------------:| ----------:| ----------:| ------------:|
//| CountWordsBenchmark | 749.48 ns | 14.623 ns | 21.435 ns | 739.40 ns |
//| ContainsWordBenchmark | 220.23 ns | 3.590 ns | 2.998 ns | 219.66 ns |
//| CountLettersBenchmark | 1,179.96 ns | 23.597 ns | 47.125 ns | 1,157.21 ns |
//| ContainsLetterBenchmark | 15.62 ns | 0.339 ns | 0.377 ns | 15.51 ns |
//| IsBase64EncodedBenchmark | 44.07 ns | 0.643 ns | 0.982 ns | 43.62 ns |
//| IsValidEmailBenchmark | 242.11 ns | 4.865 ns | 7.716 ns | 240.81 ns |