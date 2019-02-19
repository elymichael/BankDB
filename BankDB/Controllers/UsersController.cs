namespace BankDB.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using BankDB.Models;
    using Microsoft.AspNet.Identity;

    public class UsersController : ApiController
    {
        private IBankDBEntities db = new BankDBEntities();

        public UsersController() { }
        public UsersController(IBankDBEntities ctx)
        {
            db = ctx;
        }
        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize]
        [Route("api/Users/GetUserData")]
        public IHttpActionResult GetUserData()
        {
            User user = null;
            int id = User.Identity.GetUserId<int>();

            if (id > 0)
            {
                user = db.Users.Find(id);
            }

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.proc_SaveUsers(user.Id, user.Name, user.Email, user.Password);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}