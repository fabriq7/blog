using Blog.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityMappingConfig.Base
{
    public class EntityTypeConfigurationBase<TBase> : IEntityTypeConfiguration<TBase> where TBase : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(c => c.Id);            
        }
    }
}
