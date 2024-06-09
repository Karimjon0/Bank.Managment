//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace Bank.Managment.Broker.Logging
{
    internal class LggingBroker
    {
        internal class LoggingBroker : ILoggingBroker
        {
            public void LogError(string userMessage)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(userMessage);
                Console.ResetColor();
            }
            public void LogInformation(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}
