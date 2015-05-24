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

        IGenericRepository<Post> Posts { get; }

        IGenericRepository<ReportedPosts> UsersReportedPosts { get; }

        IGenericRepository<Notification> Notifications { get; }

        IGenericRepository<Message> Messages { get; }

        int SaveChanges();
    }
}
