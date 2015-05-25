namespace TrafalgarSquare.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data;
    using Microsoft.AspNet.Identity;
    using TrafalgarSquare.Models;

    public class UsersController : BaseController
    {
        public UsersController(ITrafalgarSquareData data)
            : base(data)
        {
        }

        // GET: Users
        public ActionResult Index()
        {
            return this.View();
        }


        [Authorize]
        public ActionResult AddFriend(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var friendToAdd = this.Data.Users
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (friendToAdd == null)
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var adderUserId = User.Identity.GetUserId();
            var userFriend = this.Data
                .UsersFriends.All()
                .FirstOrDefault(x => (x.UserId == adderUserId && x.FriendId == friendToAdd.Id));

            // Check if it is already added
            if (userFriend != null)
            {
                if (userFriend.IsAccepted == true)
                {
                    throw new Exception("You are alredy friends.");
                }

                throw new Exception("Your friend request is waiting acceptance.");
            }

            this.Data.UsersFriends.Add(new UserFriends()
            {
                UserId = adderUserId,
                FriendId = id,
                Friend = friendToAdd,
                IsAccepted = true,
                SentFriendRequestDate = DateTime.Now
            });

            return this.View();
        }

        [Authorize]
        public ActionResult AcceptFriendRequest(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var newFriend = this.Data.Users
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (newFriend == null)
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var acceptorUserId = User.Identity.GetUserId();
            var userFriend = this.Data
                .UsersFriends.All()
                .FirstOrDefault(x => (x.UserId == acceptorUserId && x.FriendId == newFriend.Id));

            // Check if they are already friends
            if (userFriend != null)
            {
                if (userFriend.IsAccepted == true)
                {
                    throw new Exception("You are alredy friends.");
                }

                // accept request again for delted friend
                userFriend.IsAccepted = true;
                userFriend.SentFriendRequestDate = DateTime.Now;
            }
            else
            {
                var isValidRequest =
                    this.Data.UsersFriends
                    .All()
                    .Any(x => x.UserId == id && x.FriendId == acceptorUserId && x.IsAccepted == true);

                if (!isValidRequest)
                {
                    throw new Exception("Invalid friend request!");
                }

                this.Data.UsersFriends.Add(new UserFriends()
                {
                    UserId = acceptorUserId,
                    FriendId = newFriend.Id,
                    Friend = newFriend,
                    IsAccepted = true,
                    SentFriendRequestDate = DateTime.Now
                });
            }


            this.Data.SaveChanges();
            return this.View();
        }
    }
}