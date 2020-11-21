using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebApp21.Helper;
using WebApp21.XUnitRunner;
using Xunit.Runners;
using XUnitTestProject1;

namespace WebApp21.Facades
{
    using System.Threading;
    using System.Threading.Tasks;
    public class TestFacade
    {


        public List<string> RunTestsAsync(DTO dto)
        {
            var type = new List<Type>();
            var listResults = new List<string>();
            Assembly assembly = TestLibrary.LibraryAssembly;
            type = GetAllTypes(assembly, dto.TestTypesToRun);
            listResults = SelectTestsAsync(assembly, type);
            return listResults;

        }

        private List<Type> GetAllTypes(Assembly assembly, List<string> Namespace)
        {
            var listType = new List<Type>();
            
            foreach (var test in Namespace)
            {
                var tests = assembly.GetTypes().Where(t => t.FullName.Contains(test));
                listType.AddRange(tests);
            }
            var uniqueTests = listType.Distinct().ToList();
            return uniqueTests;
        }

        private List<string> SelectTestsAsync(Assembly assembly, IReadOnlyCollection<Type> testTypesToRun)
        {
            var listResults = new List<string>();

            var results = new RunTestResults
            {
                TestRunTime = DateTimeOffset.UtcNow
            };

            void OnTestFailed(TestFailedInfo info)
            {
                results.TestsFailCount++;
                results.FailedTests.Add(new TestResultInfo
                { TestName = info.TestDisplayName, ExceptionMessage = info.ExceptionMessage, Output = info.Output });
            }

            void OnTestPassed(TestPassedInfo info)
            {
                results.TestsPassCount++;
                results.PassedTests.Add(new TestResultInfo { TestName = info.TestDisplayName, Output = info.Output });
            }

            void OnTestStarting(TestStartingInfo info)
            {
                results.TotalTestCount++;
            }

            void OnTestSkipped(TestSkippedInfo info)
            {
                results.TestsSkipCount++;
            }

            using (var runner = new XUnitTestRunner(assembly.Location))
            {

                runner.OnTestPassed = OnTestPassed;
                runner.OnTestFailed = OnTestFailed;
                runner.OnTestStarting = OnTestStarting;
                runner.OnTestSkipped = OnTestSkipped;

                // Run selected tests.
                foreach (var type in testTypesToRun)
                {
                    ExecuteTestsAsync(runner, type.FullName);
                }
               
                foreach(var x in results.PassedTests)
                {
                    listResults.Add($"TestName: { x.TestName} -> Output: Passed");
                }
                foreach (var x in results.FailedTests)
                {
                    listResults.Add($"TestName: { x.TestName} -> Output: Failed -> Exception: {x.ExceptionMessage}");
                }
                
            }
            return listResults;
        }

        private void ExecuteTestsAsync(IXUnitTestRunner runner, string typeName)
        {
            runner.Start(typeName, parallel: true);
            Thread.Sleep(TimeSpan.FromSeconds(2));

            while(runner.Status != AssemblyRunnerStatus.Idle)
            {
                //runner.Cancel();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }
    }
}
