using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.IoC
{
    public class StructureMapKernelContainer: IContainer
    {
        private readonly StructureMap.IContainer _container;

        public StructureMapKernelContainer(StructureMap.IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}
