using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using lab6.Models;
using Microsoft.AspNet.Identity;

namespace lab6.Controllers
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public class BasePost
        {
            public String Content { get; set; }
            public int TopicId { get; set; }
            //public int UserId { get; set; }
        }

        // GET: api/Posts
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(void))]
        public IHttpActionResult PostPost(BasePost postData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser currentUser = db.Users.Find(User.Identity.GetUserId());
            Topic currentTopic = db.Topics.Find(postData.TopicId);

            Post newPost = new Post
            {
                Content = postData.Content,
                Topic = currentTopic
            };
            currentTopic.Posts.Add(newPost);

            db.Posts.Add(newPost);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.PostId == id) > 0;
        }
    }
}