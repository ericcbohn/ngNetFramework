using ngMayo.Logging.Contracts;
using Ninject.Extensions.Logging;

namespace ngMayo.Logging.LogStrategy
{
    public class WarningLogStrategy : AbstractLogStrategy
    {
        public WarningLogStrategy(ILogger logger) : base(logger) { }

        public override void Execute(LogModel log)
        {
            Logger.Warn(log.Message);
        }

        public override void Execute(string message, string data)
        {
            Logger.Warn(string.Format("Message: {0}; Data: {1}", message, data));
        }
    }
}
