using static Calculator2.Services;

namespace Calculator2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Calculator theCalculator = new Calculator();
            Services service = new Services();
           
            //Starts the application
            service.Run();
           
        }
    }
}