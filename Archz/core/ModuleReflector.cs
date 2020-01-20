﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archz.modules;

namespace Archz.core
{
    public class ModuleReflector
    {
        static public List<IModule> GetAllModules()
        {
            List<IModule> modules = new List<IModule>();
            List<string> moduleNames = GetModulesName();

            foreach(var moduleName in moduleNames)
            {
                modules.Add((IModule)CreateInstanceOfType(moduleName));
            }

            return modules;
        }

        static private List<string> GetModulesName()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.AssemblyQualifiedName).ToList();
        }

        static private object CreateInstanceOfType(string typeName)
        {
            Type type = Type.GetType(typeName);
            return Activator.CreateInstance(type);
        }
    }
}
