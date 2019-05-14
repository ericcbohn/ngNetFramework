using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ninject
{
    public static class NinjectExtensions
    {
        /// <summary>
        /// Loads modules from specified assemblies that don't already exist in the kernel.
        /// </summary>
        /// <param name="assemblies">Assemblies that may have INinjectModule implementations.</param>
        public static void LoadIfNotLoaded(this IKernel kernel, IEnumerable<Assembly> assemblies)
        {
            var existingModules = kernel.GetModules();
            var newModules = assemblies.SelectMany(a => a.GetNinjectModules())
                .Where(m => !existingModules.Any(em => em.GetType() == m.GetType()));
            kernel.Load(newModules);
        }
    }
}