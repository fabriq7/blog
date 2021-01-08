using Domain;
using Infra.EntityMappingConfig.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityMappingConfig
{
    public class PostConfiguration : EntityTypeConfigurationBase<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.ToTable("Post");

            builder.HasOne(x => x.User).WithOne().IsRequired();
        }
    }
}
