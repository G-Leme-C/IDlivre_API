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
    public class UserDriverController : ControllerBase
    {

        private readonly AppDbContext _dbContext;

        public UserDriverController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet("{id}")]
        public ActionResult<UserDriver> GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var userDriver = _dbContext
                .UsersDrivers
                .Include(ud => ud.UserClient)
                .ThenInclude(uc => uc.User)
                .FirstOrDefault(u => u.Id == id);

            if (userDriver == null) return NotFound();

            return userDriver;
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDriver userDriver)
        {

            //_dbContext.Add(userClient.User);
            //_dbContext.Add(userClient);

            _dbContext.Add(userDriver);
            _dbContext.SaveChanges();

            return Created("", userDriver);
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserDriver userDriver)
        {
            var userExists = _dbContext.UsersDrivers.AsNoTracking()
                .Where(u => u.Id == userDriver.Id 
                    && u.UserClientId == userDriver.UserClient.Id
                    && u.UserClient.UserId == userDriver.UserClient.User.Id)
                .FirstOrDefault();

            if (userExists == null) return NotFound();

            var userUpdate = _dbContext.Attach(userDriver.UserClient.User);
            userUpdate.State = EntityState.Modified;

            var userClientUpdate = _dbContext.Attach(userDriver.UserClient);
            userClientUpdate.State = EntityState.Modified;

            var userDriverUpdate = _dbContext.Attach(userDriver);
            userDriverUpdate.State = EntityState.Modified;

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userDriver = _dbContext
                .UsersDrivers
                .Include(u => u.UserClient)
                .ThenInclude(uc => uc.User)
                .FirstOrDefault(u => u.Id == id);

            if (userDriver == null) return NotFound();

            _dbContext.UsersDrivers.Remove(userDriver);
            _dbContext.UsersClient.Remove(userDriver.UserClient);
            _dbContext.Users.Remove(userDriver.UserClient.User);

            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
