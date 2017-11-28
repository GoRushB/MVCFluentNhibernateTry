using FluentNHibernate.Mapping;

namespace real_MVC_fluent_nhibernate_try.Models.Mappings
{
    public class EmployeeMap:ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmployeeId);
            Map(x => x.Name);
            Map(x => x.EmployeeArtUrl);
            References(x => x.Store);
        }
    }
}