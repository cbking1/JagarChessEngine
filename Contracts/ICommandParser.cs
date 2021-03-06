﻿using System.Collections.Concurrent;

namespace JagarEngineContracts
{
    public interface ICommandParser
    {
        ConcurrentQueue<IUciInputCommand> InputQueue { get;}
        void StartParsing();
    }
}