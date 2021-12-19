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
    public class PeopleServices : IPeopleServices
    {
        
        public Task<IEnumerable<People>> GetPeoples(ODataClient client)
        {
            return client
                .For<People>()
                .Select(x => new { x.FirstName, x.LastName, x.Gender })
                .FindEntriesAsync();
        }

    }
}
