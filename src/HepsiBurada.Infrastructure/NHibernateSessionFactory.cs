using FluentNHibernate.Cfg;
using HepsiBurada.Infrastructure.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace HepsiBurada.Infrastructure
{
    public class NHibernateSessionFactory
    {
        private readonly object lockObject = new object();
        private string _connectionString;
        private bool _create, _update;
        private ISessionFactory _sessionFactory;

        public NHibernateSessionFactory(string connectionString, bool create = false, bool update = false)
        {
            _connectionString = connectionString;
            _create = create;
            _update = update;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObject)
                {
                    if (_sessionFactory == null)
                    {
                        _sessionFactory = Fluently.Configure()
                            .Database(FluentNHibernate.Cfg.Db.SQLiteConfiguration.Standard.ConnectionString(_connectionString))
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
                            .CurrentSessionContext("call")
                            .ExposeConfiguration(cfg => BuildSchema(cfg, _create, _update))
                            .BuildSessionFactory();
                    }
                }

                return _sessionFactory;
            }
        }

        private static void BuildSchema(Configuration config, bool create = false, bool update = false)
        {
            if (create)
            {
                new SchemaExport(config).Create(false, true);
            }
            else
            {
                new SchemaUpdate(config).Execute(false, update);
            }
        }
    }
}