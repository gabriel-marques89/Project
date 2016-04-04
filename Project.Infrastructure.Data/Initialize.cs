using Project.Infrastructure.Data.NHibernate;

namespace Project.Infrastructure.Data
{
    public class Initialize
    {
        public static void StartDataBase()
        {
            NHibernateHelper.DropTables();
            NHibernateHelper.UpdateTables();
        }
    }
}
