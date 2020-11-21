using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Runners;

namespace WebApp21.XUnitRunner
{
    public class XUnitTestRunner : IXUnitTestRunner
    {
        private readonly AssemblyRunner _assemblyRunner;

        /// <summary>
        /// Creates an assembly runner that discovers and runs tests with a separate app domain.
        /// </summary>
        public XUnitTestRunner()
        { }

        /// <summary>
        /// Creates an assembly runner that discovers and runs tests without a separate app domain.
        /// </summary>
        /// <param name="assemblyFileName">The test assembly.</param>
        public XUnitTestRunner(string assemblyFileName)
        {
            _assemblyRunner = AssemblyRunner.WithoutAppDomain(assemblyFileName);
        }

        /// <summary>Set to get notification of diagnostic messages.</summary>
        public Action<DiagnosticMessageInfo> OnDiagnosticMessage
        {
            get => _assemblyRunner.OnDiagnosticMessage;
            set => _assemblyRunner.OnDiagnosticMessage = value;
        }

        /// <summary>
        /// Set to get notification of when test discovery is complete.
        /// </summary>
        public Action<DiscoveryCompleteInfo> OnDiscoveryComplete
        {
            get => _assemblyRunner.OnDiscoveryComplete;
            set => _assemblyRunner.OnDiscoveryComplete = value;
        }

        /// <summary>
        /// Set to get notification of error messages (unhandled exceptions outside of tests).
        /// </summary>
        public Action<ErrorMessageInfo> OnErrorMessage
        {
            get => _assemblyRunner.OnErrorMessage;
            set => _assemblyRunner.OnErrorMessage = value;
        }

        /// <summary>
        /// Set to get notification of when test execution is complete.
        /// </summary>
        public Action<ExecutionCompleteInfo> OnExecutionComplete
        {
            get => _assemblyRunner.OnExecutionComplete;
            set => _assemblyRunner.OnExecutionComplete = value;
        }

        /// <summary>Set to get notification of failed tests.</summary>
        public Action<TestFailedInfo> OnTestFailed
        {
            get => _assemblyRunner.OnTestFailed;
            set => _assemblyRunner.OnTestFailed = value;
        }

        /// <summary>
        /// Set to get notification of finished tests (regardless of outcome).
        /// </summary>
        public Action<TestFinishedInfo> OnTestFinished
        {
            get => _assemblyRunner.OnTestFinished;
            set => _assemblyRunner.OnTestFinished = value;
        }

        /// <summary>
        /// Set to get real-time notification of test output (for xUnit.net v2 tests only).
        /// Note that output is captured and reported back to all the test completion Info&gt;s
        /// in addition to being sent to this Info&gt;.
        /// </summary>
        public Action<TestOutputInfo> OnTestOutput
        {
            get => _assemblyRunner.OnTestOutput;
            set => _assemblyRunner.OnTestOutput = value;
        }

        /// <summary>Set to get notification of passing tests.</summary>
        public Action<TestPassedInfo> OnTestPassed
        {
            get => _assemblyRunner.OnTestPassed;
            set => _assemblyRunner.OnTestPassed = value;
        }

        /// <summary>Set to get notification of skipped tests.</summary>
        public Action<TestSkippedInfo> OnTestSkipped
        {
            get => _assemblyRunner.OnTestSkipped;
            set => _assemblyRunner.OnTestSkipped = value;
        }

        /// <summary>Set to get notification of when tests start running.</summary>
        public Action<TestStartingInfo> OnTestStarting
        {
            get => _assemblyRunner.OnTestStarting;
            set => _assemblyRunner.OnTestStarting = value;
        }

        /// <summary>Gets the current status of the assembly runner</summary>
        public AssemblyRunnerStatus Status => _assemblyRunner.Status;

        /// <summary>
        /// Set to be able to filter the test cases to decide which ones to run. If this is not set,
        /// then all test cases will be run.
        /// </summary>
        public Func<ITestCase, bool> TestCaseFilter
        {
            get => _assemblyRunner.TestCaseFilter;
            set => _assemblyRunner.TestCaseFilter = value;
        }

        /// <summary>
        /// Starts running tests from a single type (if provided) or the whole assembly (if not). This call returns
        /// immediately, and status results are dispatched to the Info&gt;s on this class. Callers can check <see cref="P:Xunit.Runners.AssemblyRunner.Status" />
        /// to find out the current status.
        /// </summary>
        /// <param name="typeName">The (optional) type name of the single test class to run</param>
        /// <param name="diagnosticMessages">Set to <c>true</c> to enable diagnostic messages; set to <c>false</c> to disable them.
        /// By default, uses the value from the assembly configuration file.</param>
        /// <param name="methodDisplay">Set to choose the default display name style for test methods.
        /// By default, uses the value from the assembly configuration file. (This parameter is ignored for xUnit.net v1 tests.)</param>
        /// <param name="methodDisplayOptions">Set to choose the default display name style options for test methods.
        /// By default, uses the value from the assembly configuration file. (This parameter is ignored for xUnit.net v1 tests.)</param>
        /// <param name="preEnumerateTheories">Set to <c>true</c> to pre-enumerate individual theory tests; set to <c>false</c> to use
        /// a single test case for the theory. By default, uses the value from the assembly configuration file. (This parameter is ignored
        /// for xUnit.net v1 tests.)</param>
        /// <param name="parallel">Set to <c>true</c> to run test collections in parallel; set to <c>false</c> to run them sequentially.
        /// By default, uses the value from the assembly configuration file. (This parameter is ignored for xUnit.net v1 tests.)</param>
        /// <param name="maxParallelThreads">Set to 0 to use unlimited threads; set to any other positive integer to limit to an exact number
        /// of threads. By default, uses the value from the assembly configuration file. (This parameter is ignored for xUnit.net v1 tests.)</param>
        /// <param name="internalDiagnosticMessages">Set to <c>true</c> to enable internal diagnostic messages; set to <c>false</c> to disable them.
        /// By default, uses the value from the assembly configuration file.</param>
        public void Start(
            string typeName = null,
            bool? diagnosticMessages = null,
            TestMethodDisplay? methodDisplay = null,
            TestMethodDisplayOptions? methodDisplayOptions = null,
            bool? preEnumerateTheories = null,
            bool? parallel = null,
            int? maxParallelThreads = null,
            bool? internalDiagnosticMessages = null)
        {
            _assemblyRunner.Start(typeName, diagnosticMessages, methodDisplay, methodDisplayOptions, preEnumerateTheories, parallel,
                maxParallelThreads, internalDiagnosticMessages);
        }

        /// <summary>
        /// Call to request that the current run be cancelled. Note that cancellation may not be
        /// instantaneous, and even after cancellation has been acknowledged, you can expect to
        /// receive all the cleanup-related messages.
        /// </summary>
        public void Cancel()
        {
            _assemblyRunner.Cancel();
        }

        public void Dispose()
        {
            _assemblyRunner?.Dispose();
        }
    }
}
