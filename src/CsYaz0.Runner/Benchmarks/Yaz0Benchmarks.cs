using BenchmarkDotNet.Attributes;
using CsYaz0.Marshalling;

namespace CsYaz0.Runner.Benchmarks;

[MemoryDiagnoser(true)]
public class Yaz0Benchmarks
{
    [Benchmark]
    public void Compress()
    {
        using DataMarshal marshal = Yaz0.Compress(Assets.Uncompressed);
    }

    [Benchmark]
    public void Decompress()
    {
        byte[] _ = Yaz0.Decompress(Assets.Compressed);
    }
}
