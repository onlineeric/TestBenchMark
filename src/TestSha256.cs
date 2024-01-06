using System.Security.Cryptography;

namespace TestBenchMark;

public class TestSha256 : TestCase {
	private byte[] data;
	private SHA256 sha256;
	const int dataLength = 10000000;
	const int randomSeed = 28;

	
	public TestSha256() : base() {
		data = new byte[dataLength];
		new Random(randomSeed).NextBytes(data);
		sha256 = SHA256.Create();
	}
	public TestSha256 Run(int loopCount = 1000) {
		StartBenchmarking();
		for (int i = 0; i < loopCount; i++) {
			sha256.ComputeHash(data);
		}
		StopBenchmarking();
		return this;
	}
}