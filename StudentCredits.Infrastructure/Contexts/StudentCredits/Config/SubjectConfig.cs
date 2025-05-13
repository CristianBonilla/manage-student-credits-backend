using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentCredits.Contracts.SeedData;
using StudentCredits.Domain.Entities;

namespace StudentCredits.Infrastructure.Contexts.StudentCredits.Config;

class SubjectConfig(ISeedData? seedData) : IEntityTypeConfiguration<SubjectEntity>
{
  public void Configure(EntityTypeBuilder<SubjectEntity> builder)
  {
    builder.ToTable("Subject", "dbo")
      .HasKey(key => key.SubjectId);
    builder.Property(property => property.SubjectId)
      .HasDefaultValueSql("gen_random_uuid()");
    builder.Property(property => property.Name)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder.Property(property => property.Description)
      .HasColumnType("text");
    builder.Property(property => property.Created)
      .HasDefaultValueSql("now()");
    builder.Property(property => property.Version)
      .IsRowVersion();
    builder.HasIndex(index => new { index.Name })
      .IsUnique();
    if (seedData is not null)
      builder.HasData(seedData.StudentCredits.Subjects.GetAll());
  }
}
