using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Infrastructure.Contexts.StudentCredits.Config;

class StudentConfig(ISeedData? seedData) : IEntityTypeConfiguration<StudentEntity>
{
  public void Configure(EntityTypeBuilder<StudentEntity> builder)
  {
    builder.ToTable("Student", "dbo")
      .HasKey(key => key.StudentId);
    builder.Property(property => property.StudentId)
      .HasDefaultValueSql("gen_random_uuid()");
    builder.Property(property => property.DocumentNumber)
      .IsRequired();
    builder.Property(property => property.Firstname)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Lastname)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Email)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasDefaultValueSql("now()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasMany(many => many.StudentDetails)
      .WithOne(one => one.Student)
      .HasForeignKey(key => key.StudentId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasIndex(index => new { index.DocumentNumber, index.Email })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Students.GetAll());
  }
}

class StudentDetailConfig(ISeedData? seedData) : IEntityTypeConfiguration<StudentDetailEntity>
{
  public void Configure(EntityTypeBuilder<StudentDetailEntity> builder)
  {
    builder.ToTable("StudentDetail", "dbo")
      .HasKey(key => key.StudentDetailId);
    builder.Property(property => property.StudentDetailId)
      .HasDefaultValueSql("gen_random_uuid()");
    builder.Property(property => property.Created)
      .HasDefaultValueSql("now()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasOne(one => one.TeacherDetail)
      .WithMany()
      .HasForeignKey(key => key.TeacherDetailId);
    builder.HasOne(one => one.Student)
      .WithMany(many => many.StudentDetails)
      .HasForeignKey(key => key.StudentId);
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.StudentDetails.GetAll());
  }
}
