using System;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Context;

namespace Agency.Application
{
    public class SessionFactory : IHttpModule
    {
        private static readonly ISessionFactory _SessionFactory;
        static SessionFactory()
        {
            _SessionFactory = CreateSessionFactory();
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }
        public void Dispose()
        {
        }
        public static ISession GetCurrentSession()
        {
            return _SessionFactory.GetCurrentSession();
        }

        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = _SessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }

        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_SessionFactory);
            if (session == null) return;
            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection")))
                           .Mappings(m => m.AutoMappings.Add(CreateMappings()))
                           .CurrentSessionContext<WebSessionContext>()
                           .BuildSessionFactory();
        }

        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace != null && t.Namespace.EndsWith("Models"))
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }
    }
}
