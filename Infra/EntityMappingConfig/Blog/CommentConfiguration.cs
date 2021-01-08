using Domain;
using Infra.EntityMappingConfig.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityMappingConfig
{
    public class CommentConfiguration : EntityTypeConfigurationBase<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Comment");

            builder.HasOne(x => x.User).WithOne().IsRequired();
            builder.HasOne(x => x.Post).WithMany(x => x.Comment).IsRequired();
        }
    }
}
