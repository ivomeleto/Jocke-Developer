
namespace TrafalgarSquare.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.SignalR;
    using TrafalgarSquare.Data;

    public class CustomUserIdProvider : IUserIdProvider
    {
        private ITrafalgarSquareData data;

        public CustomUserIdProvider()
            : this(new TrafalgarSquareData(new TrafalgarSquareDbContext()))
        {
        }

        public CustomUserIdProvider(ITrafalgarSquareData data)
        {
            this.Data = data;
        }

        protected ITrafalgarSquareData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }


        public string GetUserId(IRequest request)
        {
            // your logic to fetch a user identifier goes here.

            // for example:

            var user = this.Data.Users
                .All()
                .FirstOrDefault(x => x.UserName == request.User.Identity.Name);

            string userId = null;
            if (user != null)
            {
                userId = user.Id;
            }

            return userId;
        }
    }
}