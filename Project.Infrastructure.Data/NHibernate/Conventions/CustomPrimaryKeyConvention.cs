using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;


namespace Project.Infrastructure.Data.NHibernate.Conventions
{
    public class CustomPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}
