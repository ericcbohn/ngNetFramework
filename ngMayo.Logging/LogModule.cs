using ngMayo.Logging.Contracts;
using ngMayo.Logging.LogStrategy;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System.Reflection;

namespace ngMayo.Logging
{
    public class LogModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ILogStrategy>().To<DebugLogStrategy>().Named("Debug");
            Kernel.Bind<ILogStrategy>().To<ErrorLogStrategy>().Named("Error");
            Kernel.Bind<ILogStrategy>().To<InfoLogStrategy>().Named("Info");
            Kernel.Bind<ILogStrategy>().To<WarningLogStrategy>().Named("Warning");

            Kernel.Bind<ILogStrategyFactory>().ToFactory(() => new UseLogTypeAsNameInstanceProvider());
        }
    }

    /// <summary>
    /// Overrides default <see cref="StandardInstanceProvider"/> to allow creation of <see cref="ILogStrategy"/> instance based on the <see cref="LogType"/> parameter passed to the factory method.
    /// </summary>
    public class UseLogTypeAsNameInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(MethodInfo methodInfo, object[] arguments)
        {
            return arguments[0].ToString();
        }
    }
}
