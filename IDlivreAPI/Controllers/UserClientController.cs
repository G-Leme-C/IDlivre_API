using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDlivreAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDlivreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserClientController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public ActionResult<UserClient> GetById(int id)
        {
            var userClient = _dbContext
                .UsersClient
                .Include(uc => uc.User)
                .FirstOrDefault(u => u.UserId == id);

            return userClient;
        }


        [HttpPost]
        public ActionResult Post([FromBody] UserClient userClient)
        {

            //_dbContext.Add(userClient.User);
            //_dbContext.Add(userClient);

            _dbContext.Add(userClient);
            _dbContext.SaveChanges();

            return Created("", userClient);
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserClient userClient)
        {
            var userUpdate = _dbContext.Attach(userClient.User);
            userUpdate.State = EntityState.Modified;

            var userClientUpdate = _dbContext.Attach(userClient);
            userClientUpdate.State = EntityState.Modified;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userClient = _dbContext
                .UsersClient
                .Include(u => u.User)
                .FirstOrDefault(u => u.UserId == id);

            if (userClient == null) return NotFound();

            _dbContext.UsersClient.Remove(userClient);
            _dbContext.Users.Remove(userClient.User);

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
