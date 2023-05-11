namespace TestBenchMark;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

public class BenchmarkExample
{
	const int loopCount = 1000;

	public static byte[] TestSha256(byte[] data, SHA256 sha256)
	{
		byte [] result = new byte[0];
		for (int i = 0; i < loopCount; i++) {
			result = sha256.ComputeHash(data);
		}
		return result;
	}
	public static byte[] TestMd5(byte[] data, MD5 md5)
	{
		byte [] result = new byte[0];
		for (int i = 0; i < loopCount; i++) {
			result = md5.ComputeHash(data);
		}
		return result;
	}

	public static void Main()
	{
		byte[] data = new byte[10000000];
		new Random(42).NextBytes(data);

		SHA256 sha256 = SHA256.Create();
		MD5 md5 = MD5.Create();
		var process = Process.GetCurrentProcess();

		var startTime = process.TotalProcessorTime;
		var startMemory = GC.GetTotalMemory(forceFullCollection: true);		
		// start stopwatch for real time measurement
		var stopwatch = Stopwatch.StartNew();

		TestSha256(data, sha256);

		stopwatch.Stop();

		var endTime = process.TotalProcessorTime;
		var endMemory = GC.GetTotalMemory(forceFullCollection: true);

		Console.WriteLine($"SHA256 CPU Time: {(endTime - startTime).TotalMilliseconds} ms");
		Console.WriteLine($"SHA256 Memory Used: {endMemory - startMemory} bytes");
		Console.WriteLine($"SHA256 Execution Time: {stopwatch.ElapsedMilliseconds} ms");

		startTime = process.TotalProcessorTime;
		startMemory = GC.GetTotalMemory(forceFullCollection: true);		
		// start stopwatch for real time measurement
		stopwatch = Stopwatch.StartNew();

		TestMd5(data, md5);

		stopwatch.Stop();

		endTime = process.TotalProcessorTime;
		endMemory = GC.GetTotalMemory(forceFullCollection: true);

		Console.WriteLine($"MD5 CPU Time: {(endTime - startTime).TotalMilliseconds} ms");
		Console.WriteLine($"MD5 Memory Used: {endMemory - startMemory} bytes");
		Console.WriteLine($"MD5 Execution Time: {stopwatch.ElapsedMilliseconds} ms");

	}
}
