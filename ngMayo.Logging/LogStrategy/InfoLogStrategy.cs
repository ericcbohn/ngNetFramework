using ngMayo.Logging.Contracts;
using Ninject.Extensions.Logging;

namespace ngMayo.Logging.LogStrategy
{
    public class InfoLogStrategy : AbstractLogStrategy
    {
        public InfoLogStrategy(ILogger logger) : base(logger) { }

        public override void Execute(LogModel log)
        {
            Logger.Info(log.Message);
        }

        public override void Execute(string message, string data)
        {
            Logger.Info(string.Format("Message: {0}; Data: {1}", message, data));
        }
    }
}
