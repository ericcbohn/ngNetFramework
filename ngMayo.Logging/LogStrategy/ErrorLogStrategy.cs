using ngMayo.Logging.Contracts;
using Ninject.Extensions.Logging;
using System;

namespace ngMayo.Logging.LogStrategy
{
    /// <summary>
    /// Logs errors
    /// </summary>
    public class ErrorLogStrategy : AbstractLogStrategy
    {
        public ErrorLogStrategy(ILogger logger) : base(logger) { }

        public override void Execute(LogModel log)
        {
            Logger.ErrorException(log.Message, new ApplicationException(log.Data));
        }

        public override void Execute(string message, string data)
        {
            Logger.Error(string.Format("Message: {0}; Data: {1}", message, data));
        }
    }
}
