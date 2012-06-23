using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace RebelCms.Framework.Persistence.NHibernate.Mappings.Conventions
{
    public class ForeignKeyNameConvention : IHasManyConvention
    {
        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Key.Column(instance.EntityType.Name + "Id");
        }
    }
}