using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class ExampleContext : DbContext
    {
        public DbSet<Domain.PersonAggregate.Person> People { get; set; }
        public DbSet<Domain.CityAggregate.City> Cities { get; set; }

        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.Entity<Domain.PersonAggregate.Person>();
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.Entity<Domain.CityAggregate.City>();

        }
    }

    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Domain.PersonAggregate.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.PersonAggregate.Person> orderConfiguration)
        {
            orderConfiguration.ToTable("People", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name)
                .IsRequired()
                .HasColumnType("varchar(300)");
            orderConfiguration.Property(o => o.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)");
            orderConfiguration.Property(o => o.IdCity).IsRequired();
            orderConfiguration.Property(o => o.Age).IsRequired();

            orderConfiguration.HasOne(o => o.City)
                .WithMany()
                .HasForeignKey(o => o.IdCity);
        }
    }

    public class CityEntityTypeConfiguration : IEntityTypeConfiguration<Domain.CityAggregate.City>
    {
        public void Configure(EntityTypeBuilder<Domain.CityAggregate.City> orderConfiguration)
        {
            orderConfiguration.ToTable("Cities", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
            orderConfiguration.Property(o => o.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");
        }
    }

}
