﻿namespace TrafalgarSquare.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TrafalgarSquare.Models;

    public interface ITrafalgarSquareDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<UserFriends> UsersFriends { get; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<PostLikes> UsersLikes { get; set; }

        IDbSet<Comment> Comments { get; set; }
        
        IDbSet<ReportedPosts> UsersReportedPosts { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
