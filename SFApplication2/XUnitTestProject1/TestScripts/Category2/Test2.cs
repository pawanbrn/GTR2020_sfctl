using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1.TestScripts.Category2
{
    public class Test2
    {
        public ITestOutputHelper Output { get; set; }

        public Test2(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void PassedTest1()
        {
            Assert.True(true);
            Output.WriteLine("Test Passed21");
        }

        [Fact]
        public void PassedTest2()
        {
            Output.WriteLine("Test Passed22");
        }
    }
}
