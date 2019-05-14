using ngMayo.Logging.Contracts;
using Ninject.Extensions.Logging;

namespace ngMayo.Logging.LogStrategy
{
    public class DebugLogStrategy : AbstractLogStrategy
    {
        public DebugLogStrategy(ILogger logger) : base(logger) { }

        public override void Execute(LogModel log)
        {
            Logger.Debug(log.Message);
        }

        public override void Execute(string message, string data)
        {
            Logger.Debug(string.Format("Message: {0}; Data: {1}", message, data));
        }
    }
}
