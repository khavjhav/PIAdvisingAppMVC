
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace BudgetCubeApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("PiAdvisingDbContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180; // copy this line
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}