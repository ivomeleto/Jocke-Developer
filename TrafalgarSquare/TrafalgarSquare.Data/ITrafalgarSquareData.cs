namespace TrafalgarSquare.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TrafalgarSquare.Data.Repositories.Contracts;
    using TrafalgarSquare.Models;

    public interface ITrafalgarSquareData
    {
        ITrafalgarSquareDbContext Context { get; }

        IGenericRepository<User> Users { get; }

        int SaveChanges();
    }
}
