using System.Security.Cryptography;

namespace TestBenchMark;

public class TestMd5 : TestCase {
	private byte[] data;
	private MD5 md5;
	const int dataLength = 10000000;
	const int randomSeed = 28;
	
	public TestMd5() : base() {
		data = new byte[dataLength];
		new Random(randomSeed).NextBytes(data);
		md5 = MD5.Create();
	}
	public TestMd5 Run(int loopCount = 1000) {
		StartBenchmarking();
		for (int i = 0; i < loopCount; i++) {
			md5.ComputeHash(data);
		}
		StopBenchmarking();
		return this;
	}
}