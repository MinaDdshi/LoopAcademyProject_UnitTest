using LoopAcademyProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoopAcademyProject.DatabaseContext.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName);
            builder.Property(x => x.Name);
            builder.Property(x => x.SurName);
            builder.Property(x => x.PhoneNumber);
            builder.Property(x => x.Birth);
            builder.Property(x => x.NationalCode);
        }
    }
}
