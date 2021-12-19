using oData.Core.Entities;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oData.Core.Contracts
{
    public interface ITripServices
    {
        Task<IEnumerable<Trip>> GetTrips(ODataClient client);
    }
}
