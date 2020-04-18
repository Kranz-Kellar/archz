using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{
    public class CommandExecuter
    {
        public static Dictionary<string, Action> commandsWithZeroParameters;
        public static Dictionary<string, Action<object>> commandsWithOneParameter;
        public static Dictionary<string, Action<object, object>> commandsWithTwoParameters;

        public static void Init()
        {
            commandsWithZeroParameters = new Dictionary<string, Action>();
            commandsWithOneParameter = new Dictionary<string, Action<object>>();
            commandsWithTwoParameters = new Dictionary<string, Action<object, object>>();
        }

        
        public static void ExecuteCommand(Command cmd)
        {
            try
            {
                switch (cmd.countOfArguments)
                {
                    case 0:
                        commandsWithZeroParameters[cmd.cmd]();
                        break;
                    case 1:
                        commandsWithOneParameter[cmd.cmd](cmd.arguments[0]);
                        break;
                    case 2:
                        commandsWithTwoParameters[cmd.cmd](cmd.arguments[0], cmd.arguments[1]);
                        break;
                }
            }
            catch(Exception)
            {

            }
        }

        public static void AddCommand(string command, Action method)
        {
            commandsWithZeroParameters[command] = method;
        }
        public static void AddCommand(string command, Action<object> method)
        {
            commandsWithOneParameter[command] = method;
        }
        public static void AddCommand(string command, Action<object, object> method)
        {
            commandsWithTwoParameters[command] = method;
        }
    }
}
