using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CommandParsing;
using Contracts;
using Autofac;
using CommandFactory;
using ConsoleWritingService;

namespace Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<ConsoleWriter>().As<IOutputWriter>().SingleInstance();

            IContainer container = builder.Build();
            ICommandParser parser = container.Resolve<ICommandParser>();
            ConcurrentQueue<IUciInputCommand> commandInputQueue = parser.InputQueue;
            ICommandRunner runner = container.Resolve<ICommandRunner>();


        }
    }
}
