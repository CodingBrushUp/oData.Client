namespace oData.Client
{
    public interface IAction
    {
        public string Name { get; }
        string Execute();
    }
}
