using CsYaz0.Marshalling;
using System.Runtime.InteropServices;

namespace CsYaz0;

internal unsafe static partial class Unmanaged
{
    private const string LibImport = "Yaz0";

    [LibraryImport(LibImport)]
    public static partial DataMarshal Compress(byte* src, int src_len, uint alignment, int level);

    [LibraryImport(LibImport)]
    public static partial void FreeVector(nint handle);

    [LibraryImport(LibImport)]
    public static partial void ExportVector(DataMarshal handle, out byte* dst, out int dst_len);
}
