using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Project.Infrastructure.Data.NHibernate.Conventions
{
    public class CustomJoinedSubclassIdConvention : IJoinedSubclassConvention
    {
        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Table(instance.EntityType.Name + "Table");
            instance.Key.Column(instance.EntityType.Name + "Id");
        }
    }
}
