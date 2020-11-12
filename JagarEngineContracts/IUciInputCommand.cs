namespace Contracts
{
    public interface IUciInputCommand
    {
        void ExecuteCommand(IEngine engine, IOutputWriter writer);
    }
}