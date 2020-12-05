using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTracker.WebApp
{
    public class MultiEndpointBuilder : List<IEndpointConventionBuilder>, IEndpointConventionBuilder
    {
        public void Add(Action<EndpointBuilder> convention)
        {
            foreach (var builder in this)
                builder.Add(convention);
        }
    }
}
