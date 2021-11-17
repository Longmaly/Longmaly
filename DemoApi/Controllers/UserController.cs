using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Unity;
using DemoApi.Command;
using DemoApi.Dal;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var ctx = DemoApiContainer.Current.Resolve<DemoApiDbContext>();
                var users = ctx.UserModels.ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var ctx = DemoApiContainer.Current.Resolve<DemoApiDbContext>();
                var user = ctx.UserModels.Where(u => u.Id == id).FirstOrDefault();
                return Ok(user);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Create")]
        public void Post(CreateUserCommand command)
        {
            try
            {
                var ctx = DemoApiContainer.Current.Resolve<DemoApiDbContext>();

                UserModel user = new UserModel();
                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.Sex = command.Sex;
                user.Addresses = command.Addresses;

                ctx.Add(user);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Update")]
        public void Put(UpdateUserCommand command)
        {
            try
            {
                var ctx = DemoApiContainer.Current.Resolve<DemoApiDbContext>();

                if (!string.IsNullOrEmpty(command.Id.ToString()))
                {
                    var user = ctx.UserModels.SingleOrDefault(u => u.Id == command.Id);
                    if (user != null)
                    {
                        user.FirstName = command.FirstName;
                        user.LastName = command.LastName;
                        user.Sex = command.Sex;
                        user.Addresses = command.Addresses;
                        ctx.Update(user);
                        ctx.SaveChanges();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                var ctx = DemoApiContainer.Current.Resolve<DemoApiDbContext>();
                var user = ctx.UserModels.SingleOrDefault(u => u.Id == id);
                if (user != null)
                { 
                 ctx.Remove(user);
                ctx.SaveChanges();
                }
                   
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
