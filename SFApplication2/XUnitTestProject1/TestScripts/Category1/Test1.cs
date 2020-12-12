using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1.TestScripts.Category1
{
    public class Test1
    {
        public ITestOutputHelper Output { get; set; }
        public Test1(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void PassedTest1()
        {
            Assert.True(true);
            Output.WriteLine("Test Passed1");
        }

        [Fact]
        public void FailedTest1()
        {
            Output.WriteLine("Test Failed1");
            Assert.False(true);
        }
    }
}
