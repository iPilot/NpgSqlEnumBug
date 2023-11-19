using Microsoft.EntityFrameworkCore;

namespace NpgSqlEnumBug
{
    public class EnumDbContext : DbContext
    {
        private const string Schema = "enum_schema";

        public EnumDbContext(DbContextOptions<EnumDbContext> options) : base(options)
        {
        }

        public virtual required DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            // issue reproduces with and without explicitly specified schema
            modelBuilder.HasPostgresEnum<TestEnum>(Schema);
            modelBuilder.HasPostgresEnum<TestEnum2>(Schema);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}