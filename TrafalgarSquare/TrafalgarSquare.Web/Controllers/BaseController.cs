using System;
using Microsoft.AspNet.Identity;
using TrafalgarSquare.Models;
using TrafalgarSquare.Web.ViewModels.User;

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
            var topJokes = this.Data.Posts.All()
                .GroupJoin(
                   this.Data.PostsLikes.All(),
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

        public IEnumerable<PostViewModel> getByCategorieNamePostViewModels(string categorieName)
        {
            var posts = Data.Posts.All()
                .Where(p => p.Category.Name.Equals(categorieName))
                .OrderByDescending(p => p.CreatedDateTime)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Text = p.Text,
                    Resource = p.Resource,
                    CreatedDateTime = p.CreatedDateTime,
                    IsReported = p.IsReported ?? false,
                    Likes = p.LikesPost.Count(),
                    CommentsCount = p.Comments.Count(),
                    User = new UserViewModel
                    {
                        Id = p.PostOwnerId,
                        Username = p.PostOwner.UserName,
                        AvatarUrl = p.PostOwner.AvatarUrl
                    }
                })
                .Take(1)
                .ToList();

            return posts;
        }

        [Authorize]
        public void BaseForAllCategoriesPostCreat(PostCreateBindModel post)
        {
            var currentUserId = User.Identity.GetUserId();

            var postToCreate = new Post
            {
                Text = post.Text,
                Title = post.Title,

                Resource = new PostResources()
                {
                    PictureUrl = post.Resource
                },

                PostOwnerId = currentUserId,
                CreatedDateTime = DateTime.Now.AddHours(-17),
                CategoryId = post.CategoryId

            };

            Data.Posts.Add(postToCreate);
            Data.Posts.SaveChanges();
        }
    }
}