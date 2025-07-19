namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.EntityConfiguration
{
    using MajorExpress.Delivery.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Конфигурация сущности <see cref="Order"/>
    /// </summary>
    internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);

            builder.Property(order => order.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne(order => order.Client)
                .WithMany()
                .HasForeignKey("ClientId")
                .IsRequired();

            builder.HasOne(order => order.Courier)
                .WithMany()
                .HasForeignKey("CourierId");

            builder.HasOne(order => order.Cargo)
                .WithMany()
                .HasForeignKey("CargoId")
                .IsRequired();

            builder.Property(order => order.Status)
                .HasConversion(orderStatus => orderStatus.Title, title => OrderStatus.FromTitle(title));
        }
    }
}
