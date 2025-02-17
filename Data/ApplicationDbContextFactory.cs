using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspnetCoreMvcStarter.Data
{
  public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  {
    public ApplicationDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
      optionsBuilder.UseSqlServer("Server=tcp:ps3.database.windows.net,1433;Initial Catalog=ps3;Persist Security Info=False;User ID=xadmin;Password=12345678@Aa;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=true");

      return new ApplicationDbContext(optionsBuilder.Options);
    }
  }
}
