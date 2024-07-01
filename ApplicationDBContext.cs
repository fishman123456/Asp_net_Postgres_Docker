using Microsoft.EntityFrameworkCore;

namespace Asp_net_Postgres_Docker
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<EntytiMy> EntytiMies {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string useConnection = configuration.GetSection("UseConnection").Value ?? "DefaultConnection";
            string connectionString = configuration.GetConnectionString(useConnection);
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
