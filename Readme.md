# cs-yaz0

C# bindings for [syaz0](https://github.com/EPD-Libraries/syaz0)

## Benchmarks

| Method     |      Mean |     Error |    StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
| ---------- | --------: | --------: | --------: | -------: | -------: | -------: | --------: |
| Compress   | 12.830 ms | 0.0462 ms | 0.0432 ms |        - |        - |        - |     131 B |
| Decompress |  1.171 ms | 0.0069 ms | 0.0057 ms | 197.2656 | 197.2656 | 197.2656 | 1048474 B |