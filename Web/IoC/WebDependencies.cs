using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Web.IoC
{
    public class WebDependencies
    {
        public IDependencyResolver HttpDependencyResolver { get; private set; }

        public WebDependencies(IDependencyResolver httpDependencyResolver)
        {
            HttpDependencyResolver = httpDependencyResolver;
        }
    }
}