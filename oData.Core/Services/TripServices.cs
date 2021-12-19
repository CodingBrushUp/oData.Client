using oData.Core.Contracts;
using oData.Core.Entities;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oData.Core
{
    public class TripServices : ITripServices
    {
        
        public Task<IEnumerable<Trip>> GetTrips(ODataClient client)
        {
            return client
                .For<Trip>()
                .Select(x => new { x.Name, x.Description, x.Budget })
                .FindEntriesAsync();
        }

    }
}
