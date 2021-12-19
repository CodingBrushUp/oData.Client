using oData.Core.Contracts;
using oData.Core.Entities;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oData.Client.Services
{
    internal class GetInformation
    {
        private readonly IPeopleServices _peopleServices;
        private readonly ITripServices _tripServices;
        Uri _serviceUri = new Uri("https://services.odata.org/v4/TripPinServiceRW/");

        public GetInformation(IPeopleServices peopleServices, ITripServices tripServices)
        {
            _peopleServices = peopleServices;
            _tripServices = tripServices;

            var client = new ODataClient(CreateDefaultSettings());

        }

        public IEnumerable<People> GepPeopleList()
        {
            _peopleServices.GetPeoples();
        }


        ODataClientSettings CreateDefaultSettings()
        {
            return new ODataClientSettings
            {
                BaseUri = _serviceUri,
                OnTrace = (x, y) => Console.WriteLine(string.Format(x, y)),
            };
        }

    }
}
