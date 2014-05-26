using System.Web;
using System.Web.Http.Dependencies;
using Data.Utilities;
using NHibernate;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
using Utilities.IoC;
using IContainer = Utilities.IoC.IContainer;

namespace Web.IoC
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            Common();
            NHibernate();
        }

        private void Common()
        {
            For<IContainer>().Use<StructureMapKernelContainer>();
            For<IDependencyResolver>().Use<StructureMapDependencyResolver>();
        }

        private void NHibernate()
        {
            For<ISessionFactory>().Use(NHibernateHelper.SessionFactory);
            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(context => GetSession(context.GetInstance<ISessionFactory>()));
        }

        private static ISession GetSession(ISessionFactory sessionFactory)
        {
            var httpContextItems = HttpContext.Current.Items;

            ISession session;
            if (!httpContextItems.Contains(MvcApplication.SessionKey))
            {
                session = sessionFactory.OpenSession();
                httpContextItems.Add(MvcApplication.SessionKey, session);
            }
            else
            {
                session = (ISession) httpContextItems[MvcApplication.SessionKey];
            }
            return session;
        }
    }
}