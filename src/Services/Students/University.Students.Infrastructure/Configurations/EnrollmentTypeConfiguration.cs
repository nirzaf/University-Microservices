using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Students.Core.Entities;

namespace University.Students.Infrastructure.Configurations;

public class EnrollmentTypeConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments", "dbo");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.StudentId)
            .IsRequired();

        builder.Property(r => r.CourseId)
            .IsRequired();

        builder.Property(r => r.Grade);

        // builder.Property(r => r.Version)
        //     .IsRequired();

        builder.Property(r => r.IsDeleted)
            .IsRequired();

        builder.Property(r => r.LastModified)
            .IsRequired();
    }
}