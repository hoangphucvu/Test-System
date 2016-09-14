using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using TestSystem.Models;

namespace TestSystem.Controllers.API
{
    public class AdminManageController : ApiController
    {
        private TestSystemEntities db = new TestSystemEntities();

        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(passWord))
            {
                throw new Exception("Tên đăng nhập không được để trống");
            }

            var currentUser = db.Users.Where(x => x.Username.Equals(userName) && x.Password.Equals(passWord)).FirstOrDefault();
            if (currentUser != null)
            {
                System.Web.HttpContext.Current.Session.Add(Constant.UserSession, currentUser);
                return Ok(currentUser);
            }
            return BadRequest("Vui lòng kiểm tra tên đăng nhập vả mật khẩu");
        }

        // GET: api/AdminManage
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/AdminManage/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> GetUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/AdminManage/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/AdminManage
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        }

        // DELETE: api/AdminManage/5
        [ResponseType(typeof(Users))]
        public async Task<IHttpActionResult> DeleteUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            await db.SaveChangesAsync();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}