using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Web.IoC
{
    public class StructureMapDependencyResolver: StructureMapDependencyScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container) : base(container)
        {
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }
    }
}