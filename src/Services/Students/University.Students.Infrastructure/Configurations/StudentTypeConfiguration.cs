using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Students.Core.Entities;

namespace University.Students.Infrastructure.Configurations;

public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students", "dbo");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.FirstName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(r => r.LastName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(r => r.EnrollmentDate)
            .IsRequired();

        // builder.Property(r => r.Version)
        //     .IsRequired();

        builder.Property(r => r.IsDeleted)
            .IsRequired();

        builder.Property(r => r.LastModified)
            .IsRequired();
    }
}