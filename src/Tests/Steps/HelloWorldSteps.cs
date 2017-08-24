using Moq;
using SharedFeature;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    public class HelloWorldSteps
    {
        private HelloWorldService _helloWorldService;
        private Mock<IOutputWriter> _outputWriterMoq;

        [Given(@"the SharedFeature program")]
        public void GivenTheSharedFeatureProgram()
        {
            _outputWriterMoq = new Mock<IOutputWriter>();
            _helloWorldService = new HelloWorldService(_outputWriterMoq.Object);
        }

        [When(@"SharedFeature program is started")]
        public void WhenSharedFeatureProgramIsStarted()
        {
            _helloWorldService.SayHello();
        }

        [Then(@"the Hello world should be printed on the screen")]
        public void ThenTheHelloWorldShouldBePrintedOnTheScreen()
        {
            _outputWriterMoq.Verify(writer => writer.WriteLine("Hello World"));
        }
    }
}