using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Instructors.Core.Entities;

namespace University.Instructors.Infrastructure.Configurations;

public class CourseAssignmentTypeConfiguration : IEntityTypeConfiguration<CourseAssignment>
{
    public void Configure(EntityTypeBuilder<CourseAssignment> builder)
    {
        builder.ToTable("CourseAssignments", "dbo");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.InstructorId)
            .IsRequired();

        builder.Property(r => r.CourseId)
            .IsRequired();
    }
}