using Ninject.Extensions.Logging;
using System;

namespace ngMayo.Logging.Contracts
{
    public abstract class AbstractLogStrategy : ILogStrategy
    {
        protected ILogger Logger { get; set; }

        public AbstractLogStrategy(ILogger logger)
        {
            Logger = logger;
        }

        public abstract void Execute(LogModel log);

        public abstract void Execute(string message, string data);
    }
}
