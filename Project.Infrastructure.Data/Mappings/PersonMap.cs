using FluentNHibernate.Mapping;
using Project.Domain.Entities;

namespace Project.Infrastructure.Data.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.LastName);
            Map(x => x.Birthday);
            Map(x => x.Username);
            Map(x => x.Password);
        }
    }
}
