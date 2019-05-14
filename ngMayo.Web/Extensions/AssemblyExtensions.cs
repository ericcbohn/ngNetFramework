using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Reflection { 
    /// <summary>
    /// Assembly extension methods used with Ninject.
    /// </summary>
    /// <remarks>
    /// This was copied from Ninject.Infrastructure.Language source: https://github.com/ninject/Ninject/blob/master/src/Ninject/Infrastructure/Language/ExtensionsForAssembly.cs
    /// </remarks>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Determines whether the assembly has loadable <see cref="INinjectModule"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/>.</param>
        /// <returns><c>True</c> if there's any loadable <see cref="INinjectModule"/>, otherwise <c>False</c>.</returns>
        public static bool HasNinjectModules(this Assembly assembly)
        {
            return !assembly.IsDynamic && assembly.ExportedTypes.Any(IsLoadableModule);
        }

        /// <summary>
        /// Gets loadable <see cref="INinjectModule"/>s from the <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/>.</param>
        /// <returns>The loadable <see cref="INinjectModule"/>s</returns>
        public static IEnumerable<INinjectModule> GetNinjectModules(this Assembly assembly)
        {
            return assembly.IsDynamic ?
                Enumerable.Empty<INinjectModule>() :
                assembly.ExportedTypes.Where(IsLoadableModule)
                                      .Select(type => Activator.CreateInstance(type) as INinjectModule);
        }

        private static bool IsLoadableModule(Type type)
        {
            return typeof(INinjectModule).IsAssignableFrom(type)
                && !type.IsAbstract
                && !type.IsInterface
                && type.GetConstructor(Type.EmptyTypes) != null;
        }
    }
}