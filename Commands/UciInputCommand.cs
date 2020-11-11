using Contracts;

namespace Commands
{
    public class UciInputCommand : IUciInputCommand
    {
        public void ExecuteCommand(IEngine engine, IOutputWriter writer)
        {
            writer.WriteLine("id name " + engine.Name + " " + engine.Version);
            foreach (string option in engine.GetOptions())
            {
                writer.WriteLine("option name " + option);
            }
            writer.WriteLine("uciok");
        }
    }
}