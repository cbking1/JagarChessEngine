using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CommandParsing;
using Autofac;
using CommandFactory;
using ConsoleWritingService;
using System.Linq;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> temp = new List<string>();
            var t = temp.First();
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<CommandParser>().As<ICommandParser>();
            //builder.RegisterType<ConsoleWriter>().As<IOutputWriter>().SingleInstance();

            //IContainer container = builder.Build();
            //ICommandParser parser = container.Resolve<ICommandParser>();
            //ConcurrentQueue<IUciInputCommand> commandInputQueue = parser.InputQueue;
            //ICommandRunner runner = container.Resolve<ICommandRunner>();


        }
    }
}
