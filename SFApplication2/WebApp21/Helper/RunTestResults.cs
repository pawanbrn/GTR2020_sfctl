using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp21.Helper
{
    public class RunTestResults
    {
        public RunTestResults()
        {
            PassedTests = new List<TestResultInfo>();
            FailedTests = new List<TestResultInfo>();
        }

        public DateTimeOffset TestRunTime { get; set; }
        public int TotalTestCount { get; set; }
        public int TestsPassCount { get; set; }
        public int TestsFailCount { get; set; }
        public int TestsSkipCount { get; set; }
        public List<TestResultInfo> PassedTests { get; set; }
        public List<TestResultInfo> FailedTests { get; set; }
    }

    public class TestResultInfo
    {
        public string TestName { get; set; }
        public string ExceptionMessage { get; set; }
        public string Output { get; set; }
    }
}
