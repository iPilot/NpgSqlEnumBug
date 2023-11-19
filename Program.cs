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
}