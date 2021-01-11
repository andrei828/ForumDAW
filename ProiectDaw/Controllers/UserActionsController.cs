using lab6.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab6.Controllers
{
    public class UserActionsController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public class BaseTopic
        {
            public int TopicId { get; set; }
        }

        public class BaseComment
        {
            public int CommentId { get; set; }
        }

        // GET: api/UserActions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserActions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserActions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserActions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserActions/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        [ActionName("Follow")]
        public IHttpActionResult Follow(BaseTopic currentTopic)
        {
            Topic topic = db.Topics.Find(currentTopic.TopicId);
            ApplicationUser currentUser = db.Users.Find(User.Identity.GetUserId());

            topic.Followers.Add(currentUser);
            currentUser.Topics.Add(topic);
            
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        [HttpPost]
        [ActionName("Like")]
        public IHttpActionResult Like(BaseComment currentComment)
        {
            Comment comment = db.Comments.Find(currentComment.CommentId);
            ApplicationUser currentUser = db.Users.Find(User.Identity.GetUserId());

            comment.LikedBy.Add(currentUser);
            comment.Engagement.Likes += 1;
            currentUser.LikedComments.Add(comment);

            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }
    }
}
