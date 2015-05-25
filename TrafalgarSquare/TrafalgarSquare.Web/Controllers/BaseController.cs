namespace TrafalgarSquare.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using ViewModels;

    public abstract class BaseController : Controller
    {
        private ITrafalgarSquareData data;

        protected BaseController(ITrafalgarSquareData data)
        {
            this.Data = data;
        }

        protected ITrafalgarSquareData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        protected IEnumerable<TopPostViewModel> Top10Jokes()
        {
            return this.TopJokes(10);
        }

        protected IEnumerable<TopPostViewModel> TopJokes(int showNumber)
        {
            // GrouJoin prevents from changing order unlike groupBy
            var topJokes = Data.Posts.All()
                .GroupJoin(
                   Data.PostsLikes.All(),
                    x => x.Id,
                    postLikes => postLikes.PostId,
                    (post, postLikes) => new
                    {
                        post = post,
                        postLikes = postLikes.Count()
                    })
                .OrderByDescending(x => x.postLikes)
                .ThenByDescending(x => x.post.CreatedDateTime)
                .Take(showNumber)
                .Select(x => new TopPostViewModel()
                {
                    Id = x.post.Id,
                    Title = x.post.Title,
                    PostResources = x.post.Resource,
                    PostOwnerId = x.post.PostOwnerId,
                    // TODO: add UserViewModel
                    PostOwner = x.post.PostOwner,
                    LikesCount = x.post.LikesPost.Count,
                }).ToList();
            return topJokes;
        }
    }
}