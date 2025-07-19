namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.EntityConfiguration
{
    using MajorExpress.Delivery.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Конфигурация сущности <see cref="Client"/>
    /// </summary>
    internal class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);

            builder.Property(client => client.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne(client => client.User)
                .WithMany()
                .HasForeignKey("UserId")
                .IsRequired();
        }
    }
}
