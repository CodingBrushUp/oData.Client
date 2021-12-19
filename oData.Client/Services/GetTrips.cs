namespace oData.Client.Services
{
    public class GetTrips : IAction
    {
        public string Name => "GetTrips";

        public string Execute()
        {
            return Name;
        }
    }
}
