//----------------------------------------
// Great Code Team (c) All rights reserved
//----------------------------------------

namespace Bank.Managment.Broker.Logging
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
        void LogInfo(string message);
    }
}
