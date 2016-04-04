using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NLog;
using Project.Infrastructure.Data.NHibernate.Conventions;

namespace Project.Infrastructure.Data.NHibernate
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        private const string ConnectionString = "Server=DESKTOP-AT7OCR8\\SQLEXPRESS;Database=Project;Integrated Security=true";

        /// <summary>
        /// Essa função cria e/ou atualiza as tabelas no banco de dados
        /// </summary>
        /// <returns></returns>
        protected internal static ISessionFactory UpdateTables()
        {
            try
            {
                return Configuration()
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                    .BuildSessionFactory();
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e);
            }

            return null;
        }

        /// <summary>
        /// Essa função exclui as tabelas no banco de dados
        /// </summary>
        /// <returns></returns>
        protected internal static ISessionFactory DropTables()
        {
            return Configuration()
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Drop(true, true))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Este atributo retorna a conexão com um banco de dados
        /// </summary>
        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        /// <summary>
        /// Essa função retorna uma sessão de conexão
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSessionFactory()
        {
            return Configuration().BuildSessionFactory();
        }

        /// <summary>
        /// Essa função retorna a configuração base do nHibernate
        /// </summary>
        /// <returns></returns>
        private static FluentConfiguration Configuration()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Initialize>())
                .Mappings(m => m.FluentMappings.Conventions.AddFromAssemblyOf<CustomEnumConvention>())
                .Mappings(m => m.FluentMappings.Conventions.AddFromAssemblyOf<CustomPrimaryKeyConvention>());
        }
    }
}
