namespace CsYaz0.Tests;

public class Assets
{
    public static readonly byte[] Uncompressed = File.ReadAllBytes($"{AppContext.BaseDirectory}/Assets/Uncompressed.test");
    public static readonly byte[] Compressed = File.ReadAllBytes($"{AppContext.BaseDirectory}/Assets/Compressed.test");
}
