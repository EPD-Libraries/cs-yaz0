using CsYaz0.Marshalling;
using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace CsYaz0;

public unsafe static partial class Yaz0
{
    public const uint MAGIC = 0x307A6159;

    public static DataMarshal Compress(ReadOnlySpan<byte> src, uint alignment = 0, int level = 7)
    {
        fixed (byte* src_ptr = src) {
            return Unmanaged.Compress(src_ptr, src.Length, alignment, level);
        }
    }

    public static byte[] Decompress(ReadOnlySpan<byte> data)
    {
        uint bufferSize = BinaryPrimitives.ReverseEndianness(MemoryMarshal.Read<uint>(data[4..8]));
        byte[] result = new byte[bufferSize];
        Decompress(data, result);
        return result;
    }

    public static void Decompress(ReadOnlySpan<byte> src, Span<byte> dst)
    {
        if (MemoryMarshal.Cast<byte, uint>(src[0..4])[0] != MAGIC) {
            throw new InvalidOperationException("""
                Invalid Yaz0 magic
                """);
        }

        int src_it = 16;
        int dst_it = 0;

        while (dst_it < dst.Length) {
            byte header = src[src_it++];
            for (int i = 0; i < 8 && dst_it < dst.Length; i++) {
                if ((header & 0x80) != 0) {
                    dst[dst_it++] = src[src_it++];
                }
                else {
                    byte pair = src[src_it++];
                    int distance = (((pair & 0xF) << 8) | src[src_it++]) + 1;
                    int length = (pair >> 4) + 2;

                    if (length == 2) {
                        length = src[src_it++] + 18;
                    }

                    if (distance <= dst_it) {
                        for (int j = 0; j < length; j++) {
                            dst[dst_it] = dst[dst_it - distance];
                            dst_it++;
                        }
                    }
                }

                header <<= 1;
            }
        }
    }
}
