namespace ngMayo.Logging.Contracts
{
    /// <summary>
    /// IoC container provides instance to get concrete implementations of ILogStrategy based on the type of log (error, info, debug, warning), and logs appropriately.
    /// </summary>
    public interface ILogStrategyFactory
    {
        ILogStrategy GetStrategy(LogType logType);
    }
}
