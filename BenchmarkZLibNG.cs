using System;
using System.IO;
using System.IO.Compression;
using Xunit;

namespace BenchmarkZLibNG;

/*
File: filename.txt
| X/Y                   | NoCompression | Fastest | Optimal | SmallestSize |
|-----------------------|---------------|---------|---------|--------------|
| Windows 64 zlib       |               |         |         |              |
| Windows 64 zlib-ng    |               |         |         |              |
| Linux 64 zlib         |               |         |         |              |
| Linux 64 zlib-ng      |               |         |         |              |
| Mac 64 zlib           |               |         |         |              |
| Mac 64 zlib-ng        |               |         |         |              |
| Windows arm64 zlib    |               |         |         |              |
| Windows arm64 zlib-ng |               |         |         |              |
| Linux arm64 zlib      |               |         |         |              |
| Linux arm64 zlib-ng   |               |         |         |              |
| Mac arm64 zlib        |               |         |         |              |
| Mac arm64 zlib-ng     |               |         |         |              |
*/

public static class MyClass
{
    private static (long, double) GetZipLengthAndMilliseconds(string sourceDirectoryName, CompressionLevel level)
    {
        string destinationArchiveFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()  + ".zip");
        
        DateTime start = DateTime.Now;
        ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, level, true);
        DateTime end = DateTime.Now;

        long length = new FileInfo(destinationArchiveFileName).Length;
        double ms = (end - start).TotalMilliseconds;

        return (length, ms);
    }

    [Fact]
    public static void MyTest()
    {
        string os = "MacOS";
        string arch = "arm64";
        string version = "zlib";

        CompressionLevel[] levels = [CompressionLevel.NoCompression, CompressionLevel.Fastest, CompressionLevel.Optimal, CompressionLevel.SmallestSize];

        Console.WriteLine("| OS+Arch+Version / CompressionLevel | NoCompression | Fastest | Optimal | SmallestSize |");

        foreach (CompressionLevel level in levels)
        {
            Console.Write($"| {os} {arch} {version}");

            Get
            Console.Write(" | {length}");
        }
        Console.WriteLine();
    }
}
