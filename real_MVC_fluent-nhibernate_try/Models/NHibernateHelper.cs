using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace real_MVC_fluent_nhibernate_try.Models
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory
        {
            get
            {
                return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .FromAppSetting("connectionString"))
                        .ShowSql())

                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<Store>())

                    .ExposeConfiguration(cfg => new SchemaExport(cfg)
                        .Create(false, false))

                    .BuildSessionFactory();
            }
        }

        public static ISession OpenSession() => sessionFactory.OpenSession();
    }
}