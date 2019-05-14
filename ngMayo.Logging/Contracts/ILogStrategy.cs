using System;

namespace ngMayo.Logging.Contracts
{
    public interface ILogStrategy
    {
        void Execute(LogModel log);
        void Execute(string message, string data);
    }
}
