using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml;
using System.Xml.Serialization;
using lab6.Models;
using Microsoft.AspNet.Identity;

namespace lab6.Controllers
{
    public class CommentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public class BaseComment
        {
            public String Content { get; set; }
            public int PostId { get; set; }
            //public int UserId { get; set; }
        }

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        // GET: api/Comments/5
        //[ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(new {id = comment.CommentId, content = comment.Content, post = comment.Post.Content});
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.CommentId)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [ResponseType(typeof(void))]
        public IHttpActionResult PostComment(BaseComment commentData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser currentUser = db.Users.Find(User.Identity.GetUserId());
            Post currentPost = db.Posts.Find(commentData.PostId);

            Comment newComment = new Comment {
                Post = currentPost,
                Content = commentData.Content,
                Author = currentUser.UserName,
                Engagement = new Engagement { Likes = 0 }
            };
            currentPost.Comments.Add(newComment);
            
            db.Comments.Add(newComment);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.Comments.Count(e => e.CommentId == id) > 0;
        }
    }
}