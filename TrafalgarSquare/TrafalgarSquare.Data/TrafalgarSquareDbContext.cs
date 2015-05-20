namespace TrafalgarSquare.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TrafalgarSquare.Data.Migrations;
    using TrafalgarSquare.Models;

    public class TrafalgarSquareDbContext : IdentityDbContext<User>, ITrafalgarSquareDbContext
    {
        public TrafalgarSquareDbContext()
            : base("TrafalgarSquare", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrafalgarSquareDbContext, Configuration>());
        }

        public static TrafalgarSquareDbContext Create()
        {
            return new TrafalgarSquareDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
