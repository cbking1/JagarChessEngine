using Contracts;

namespace Commands
{
    public class IsReadyCommand : IUciInputCommand
    {
        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            engine.WaitUntilready();
            writer.WriteLine("readyok");
        }
    }
}