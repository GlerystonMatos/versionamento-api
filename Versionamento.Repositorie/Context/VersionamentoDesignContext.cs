using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Versionamento.Data.Context
{
    public class DesignVersionamentoContext : IDesignTimeDbContextFactory<VersionamentoContext>
    {
        public VersionamentoContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<VersionamentoContext> builder = new DbContextOptionsBuilder<VersionamentoContext>();
            builder.UseSqlServer("Data Source=10.0.0.131\\SQLEXPRESS;Initial Catalog=Versionamento;Persist Security Info=True;User ID=sa;Password=1234");
            return new VersionamentoContext(builder.Options);
        }
    }
}