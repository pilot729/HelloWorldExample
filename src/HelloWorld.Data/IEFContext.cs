using System.Data.Entity;
using HelloWorld.Data.DTO;
using System.Data.Entity.Infrastructure;

namespace HelloWorld.Data
{
    public interface IEFContext
    {
        DbSet<Greetings> HelloWorlds { get; set; }
        int SaveChanges();
        Database Database { get; }
        DbChangeTracker ChangeTracker { get; }
    }
}