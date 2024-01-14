using System.Runtime.InteropServices;

namespace CsYaz0.Tests;

public class OperationsTests
{
    [Fact]
    public void VerifyCompression()
    {
        // For some reason the resolver breaks
        // when running tests, so we load from
        // the folder explicitly.
        NativeLibrary.Load(
            Path.Combine(AppContext.BaseDirectory, "runtimes", GetRuntime(), "native", GetLibrary())
        );

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

    private static string GetRuntime()
    {
        if (OperatingSystem.IsWindows()) {
            return "win-x64";
        }

        if (OperatingSystem.IsLinux()) {
            return "linux-x64";
        }

        if (OperatingSystem.IsMacOS()) {
            return "osx";
        }

        throw new NotSupportedException($"""
            The current operating system is not supported.
            """);
    }

    private static string GetLibrary()
    {
        if (OperatingSystem.IsWindows()) {
            return "Yaz0.dll";
        }

        if (OperatingSystem.IsLinux()) {
            return "Yaz0.so";
        }

        if (OperatingSystem.IsMacOS()) {
            return "Yaz0.dylib";
        }

        throw new NotSupportedException($"""
            The current operating system is not supported.
            """);
    }
}
