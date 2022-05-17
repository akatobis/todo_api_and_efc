using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todoAPI.Models;

namespace todoAPI.Infrastructure
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("todo")
                .HasKey(item => item.Id);

            builder.Property(item => item.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.IsDone)
                .IsRequired();

        }
    }
}
