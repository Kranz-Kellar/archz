using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archz.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Archz.core.Tests
{
    [TestClass()]
    public class CommandTests
    {
        [TestMethod()]
        public void CommandTest()
        {
            var command = new Command("test", new List<string>() { "test", "test" });
            Assert.Equals(command.countOfArguments, 2);
        }
    }
}