namespace CsYaz0.Runner;

public class Assets
{
    public static readonly byte[] Uncompressed = File.ReadAllBytes($"{AppContext.BaseDirectory}/Assets/Uncompressed.bnchmrk");
    public static readonly byte[] Compressed = File.ReadAllBytes($"{AppContext.BaseDirectory}/Assets/Compressed.bnchmrk");
}
