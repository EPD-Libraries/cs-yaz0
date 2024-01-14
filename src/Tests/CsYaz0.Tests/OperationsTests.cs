namespace CsYaz0.Tests;

public class OperationsTests
{
    [Fact]
    public void VerifyCompression()
    {
        Yaz0.Compress(Assets.Uncompressed)
            .AsSpan()
            .SequenceEqual(Assets.Compressed)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void VerifyDecompression()
    {
        Yaz0.Decompress(Assets.Compressed)
            .AsSpan()
            .SequenceEqual(Assets.Uncompressed)
            .Should()
            .BeTrue();
    }
}
