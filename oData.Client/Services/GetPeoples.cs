using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oData.Client.Services
{
    public class GetPeoples : IAction
    {
        public string Name => "GetPeoples";

        public string Execute()
        {
            return Name;
        }
    }
}
