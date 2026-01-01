
namespace WebStore_z80.Models.DBContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
          : base(options)
        {
        }

       public DbSet<Product> product {  get; set; }
    }
}
