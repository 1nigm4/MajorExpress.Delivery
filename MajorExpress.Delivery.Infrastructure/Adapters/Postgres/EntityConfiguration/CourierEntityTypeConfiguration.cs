namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.EntityConfiguration
{
    using MajorExpress.Delivery.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Конфигурация сущности <see cref="Courier"/>
    /// </summary>
    internal class CourierEntityTypeConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.HasKey(courier => courier.Id);

            builder.Property(courier => courier.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne(courier => courier.User)
                .WithMany()
                .HasForeignKey("UserId")
                .IsRequired();
        }
    }
}
