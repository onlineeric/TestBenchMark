namespace TestBenchMark;

using System;
using System.Diagnostics;

public class TestCase
{
	protected Process process;
	protected Stopwatch stopwatch;
	private TimeSpan startCpuTime;
	private long startMemory;
	public TestResult? Result { get; set; }
	
	public TestCase()
	{
		process = Process.GetCurrentProcess();
		stopwatch = new Stopwatch();
	}
	protected void StartBenchmarking() {
		startCpuTime = process.TotalProcessorTime;
		startMemory = GC.GetTotalMemory(forceFullCollection: true);
		stopwatch.Start();
	}
	protected void StopBenchmarking() {
		stopwatch.Stop();
		var endCpuTime = process.TotalProcessorTime;
		var endMemory = GC.GetTotalMemory(forceFullCollection: true);

		Result = new TestResult {
			CpuTime = (endCpuTime - startCpuTime).TotalMilliseconds,
			MemoryUsed = endMemory - startMemory,
			ExecutionTime = stopwatch.ElapsedMilliseconds,
			FinishedTime = DateTime.Now
		};
	}
}