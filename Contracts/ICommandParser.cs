using System.Collections.Concurrent;

namespace Contracts
{
    public interface ICommandParser
    {
        ConcurrentQueue<IUciInputCommand> InputQueue { get;}
        void StartParsing();
    }
}