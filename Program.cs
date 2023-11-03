using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NpgSqlEnumBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("Postgres");

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dataSourceBuilder.MapEnum<TestEnum>();
            dataSourceBuilder.MapEnum<TestEnum2>();

            builder.Services.AddDbContext<EnumDbContext>(o => o.UseNpgsql(dataSourceBuilder.Build()));

            var app = builder.Build();

            app.Run();
        }
    }

    public class EnumDbContext : DbContext
    {
        public EnumDbContext(DbContextOptions<EnumDbContext> options) : base(options)
        {
        }
        public virtual required DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<TestEnum>();
            modelBuilder.HasPostgresEnum<TestEnum2>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }

    public class TestEntity
    {
        public ulong Id { get; set; }

        public TestEnum Enum { get; set; }

        public TestEnum2 Enum2 { get; set; }
    }
}