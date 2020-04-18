using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core
{
    public class Command
    {
        public string cmd { get; }
        public List<string> arguments { get; }

        public int countOfArguments { get; }
        public Command(string cmd, List<string> args)
        {
            this.cmd = cmd;
            this.arguments = args;
            this.countOfArguments = args.Count;
        }
    }
}
