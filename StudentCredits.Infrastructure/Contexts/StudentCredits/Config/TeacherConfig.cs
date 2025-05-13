using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;
using StudentCredits.Domain.Entities.Details;

namespace StudentCredits.Infrastructure.Contexts.StudentCredits.Config;

class TeacherConfig(ISeedData? seedData = null) : IEntityTypeConfiguration<TeacherEntity>
{
  public void Configure(EntityTypeBuilder<TeacherEntity> builder)
  {
    builder.ToTable("Teacher", "dbo")
      .HasKey(key => key.TeacherId);
    builder.Property(property => property.TeacherId)
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
    builder.Property(property => property.Profession)
      .HasMaxLength(30)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasDefaultValueSql("now()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasMany(many => many.Details)
      .WithOne(one => one.Teacher)
      .HasForeignKey(key => key.TeacherId)
      .OnDelete(DeleteBehavior.Cascade);
    builder.HasIndex(index => new { index.DocumentNumber, index.Email })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Teachers.GetAll());
  }
}

class TeacherDetailConfig(ISeedData? seedData) : IEntityTypeConfiguration<TeacherDetailEntity>
{
  public void Configure(EntityTypeBuilder<TeacherDetailEntity> builder)
  {
    builder.ToTable("TeacherDetail", "dbo")
      .HasKey(key => key.TeacherDetailId);
    builder.Property(property => property.TeacherDetailId)
      .HasDefaultValueSql("gen_random_uuid()");
    builder.Property(property => property.Credits)
      .HasPrecision(2, 1)
      .IsRequired();
    builder.Property(property => property.Created)
      .HasDefaultValueSql("now()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasOne(one => one.Teacher)
      .WithMany(many => many.Details)
      .HasForeignKey(key => key.TeacherId);
    builder.HasOne(one => one.Subject)
      .WithMany()
      .HasForeignKey(key => key.SubjectId);
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.TeacherDetails.GetAll());
  }
}
