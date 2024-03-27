using Microsoft.EntityFrameworkCore;

namespace GymHyR.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
