using Microsoft.Win32.SafeHandles;
using System.Runtime.CompilerServices;

namespace CsYaz0.Marshalling;

public class DataMarshal() : SafeHandleMinusOneIsInvalid(true)
{
    public static implicit operator Span<byte>(DataMarshal dataMarshal) => dataMarshal.AsSpan();
    public unsafe Span<byte> AsSpan()
    {
        Unmanaged.ExportVector(this, out byte* dst, out int dst_len);
        return new(dst, dst_len);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] ToArray() => AsSpan().ToArray();

    protected override bool ReleaseHandle()
    {
        Unmanaged.FreeVector(handle);
        return true;
    }
}
