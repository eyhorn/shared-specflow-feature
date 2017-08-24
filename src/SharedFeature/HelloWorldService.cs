namespace SharedFeature
{
    public class HelloWorldService
    {
        private readonly IOutputWriter _outputWriter;

        public HelloWorldService(IOutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
        }

        public void SayHello()
        {
            var helloWorld = "Hello World";
            _outputWriter.WriteLine(helloWorld);
        }
    }
}