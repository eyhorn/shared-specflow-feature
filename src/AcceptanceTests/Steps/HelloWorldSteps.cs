using System.Diagnostics;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class HelloWorldSteps
    {
        private readonly Process _process;
        private readonly TaskCompletionSource<string> _processOutputTaskCompletionSource;

        public HelloWorldSteps(Process process)
        {
            _process = process;
            _processOutputTaskCompletionSource = new TaskCompletionSource<string>();
        }

        [Given(@"the SharedFeature program")]
        public void GivenTheSharedFeatureProgram()
        {
            _process.StartInfo = new ProcessStartInfo
            {
                FileName = "SharedFeature.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            _process.OutputDataReceived += OutputHandler;
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (_processOutputTaskCompletionSource.Task.IsCompleted) return;
            _processOutputTaskCompletionSource.SetResult(e.Data);
        }

        [When(@"SharedFeature program is started")]
        public void WhenSharedFeatureProgramIsStarted()
        {
            _process.Start();
            _process.BeginOutputReadLine();
        }

        [Then(@"the '(.*)' should be printed on the screen")]
        public void ThenTheShouldBePrintedOnTheScreen(string expectedString)
        {
            var processOutput = _processOutputTaskCompletionSource.Task.Result;
            Assert.Equal(expectedString, processOutput);
        }
    }
}