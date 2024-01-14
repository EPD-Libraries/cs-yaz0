# cs-yaz0

C# bindings for [syaz0](https://github.com/zeldamods/syaz0)

## Benchmarks

| Method     |      Mean |     Error |    StdDev |     Gen0 |     Gen1 |     Gen2 | Allocated |
| ---------- | --------: | --------: | --------: | -------: | -------: | -------: | --------: |
| Compress   | 40.634 ms | 0.3524 ms | 0.3124 ms |        - |        - |        - |     521 B |
| Decompress |  1.182 ms | 0.0102 ms | 0.0095 ms | 199.2188 | 199.2188 | 199.2188 | 1048474 B |