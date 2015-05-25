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
                userFriend.IsAccepted = true;
                userFriend.SentFriendRequestDate = DateTime.Now;
            }
            else
            {
                this.Data.UsersFriends.Add(new UserFriends()
                {
                    UserId = adderUserId,
                    FriendId = id,
                    Friend = friendToAdd,
                    IsAccepted = true,
                    SentFriendRequestDate = DateTime.Now
                });
            }

            Notification model;

            // Send Friend Request.
            var frinedRequest = this.Data.UsersFriends
                .All()
                .FirstOrDefault(x => (x.UserId == friendToAdd.Id && x.FriendId == adderUserId));
            if (frinedRequest != null)
            {
                if (frinedRequest.IsAccepted == false)
                {
                    // TODO use SignalR To send notifiacation (to Current User)
                    model = new Notification()
                    {
                        RecepientId = adderUserId,
                        Text = "Your friend request is waiting acceptance.",
                        SendDateTime = DateTime.Now
                    };
                }
                else
                {
                    // TODO use SignalR To send notifiacation (to Current User)
                    model = new Notification()
                    {
                        RecepientId = adderUserId,
                        Text = string.Format("You are now friends with {0}", friendToAdd.UserName),
                        SendDateTime = DateTime.Now
                    };
                }
            }
            else
            {
                this.Data.UsersFriends.Add(new UserFriends()
                {
                    UserId = friendToAdd.Id,
                    FriendId = adderUserId,
                    IsAccepted = false,
                    SentFriendRequestDate = DateTime.Now
                });

                // TODO use SignalR To send notifiacation  (to Current and Friend User)
                model = new Notification()
                {
                    RecepientId = adderUserId,
                    Text = string.Format("Friend request sent to: {0}", friendToAdd.UserName),
                    SendDateTime = DateTime.Now
                };
            }

            this.Data.SaveChanges();
            return this.View(model);
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
            }

            this.Data.SaveChanges();
            return this.View();
        }

        [Authorize]
        public ActionResult RemoveFriend(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var frinedForRemove = this.Data.Users
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (frinedForRemove == null)
            {
                throw new ArgumentNullException("id", "Invalid user ID.");
            }

            var userId = User.Identity.GetUserId();
            var userFriend = this.Data
                .UsersFriends.All()
                .FirstOrDefault(x => (x.UserId == userId && x.FriendId == frinedForRemove.Id));

            // Check if they are already friends
            if (userFriend == null || userFriend.IsAccepted != true)
            {
                throw new Exception("You are not friends and cannot remove from friends.");
            }

            userFriend.IsAccepted = false;

            this.Data.SaveChanges();
            return new EmptyResult();
        }
    }
}