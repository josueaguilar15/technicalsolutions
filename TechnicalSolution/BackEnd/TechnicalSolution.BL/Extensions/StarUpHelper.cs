using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TechnicalSolution.DAL.Core;

namespace TechnicalSolution.BL.Extensions
{
    public static class StartUpHelper
    {

        /// <summary>
        /// Extension Method to inject the DAL and BL interfaces from dll
        /// </summary>
        /// <param name="services">Extension method owner</param>
        public static void AddDIBL(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            Assembly assembly = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, $"TechnicalSolution.BL.dll"));
            IEnumerable<Type> types = assembly.ExportedTypes.Where(x => x.IsClass && x.IsPublic && x.Name.EndsWith("BL"));
            foreach (Type type in types)
            {
                services.AddTransient(type.GetInterface($"I{type.Name}"), type);
            }
            assembly = Assembly.LoadFrom(Path.Combine(AppContext.BaseDirectory, $"TechnicalSolution.DAL.dll"));
            types = assembly.ExportedTypes.Where(x => x.IsClass && x.IsPublic && x.Name.EndsWith("DAL"));
            foreach (Type type in types)
            {
                services.AddTransient(type.GetInterface($"I{type.Name}"), type);
            }
        }
    }
}
