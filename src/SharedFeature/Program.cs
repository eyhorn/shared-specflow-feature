using System;

namespace SharedFeature
{
    internal class Program
    {
        private static void Main()
        {
            var helloWorldService = new HelloWorldService(new OutputWriter());
            helloWorldService.SayHello();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}