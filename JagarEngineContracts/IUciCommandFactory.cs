using Contracts;
using System.Runtime.CompilerServices;

namespace CommandFactory
{
    public interface IUciCommandFactory
    {
        IUciInputCommand CreateCommand(string commandText);
    }
}