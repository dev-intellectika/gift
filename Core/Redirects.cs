using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftApi.Core
{
    public class Redirects: Dictionary<string, string>
    {
        public Redirects(Dictionary<string, string> store)
            : base(store)
        {
        }

        public Redirects()
        {

        }
    }
}
