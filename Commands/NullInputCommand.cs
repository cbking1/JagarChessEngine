using Contracts;

namespace Commands
{
    public class NullInputCommand : IUciInputCommand
    {
        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            return;
        }
    }
}