using Microsoft.AspNetCore.Mvc;
using MySchool.WebApi.Models;
using MySchool.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MySchoolContext dbContext;

        public UserController()
        {
            dbContext = new MySchoolContext();
        }

        [HttpGet]
        public List<UsersModel> Get()
        {
            var users = dbContext.Users
                .Where(x => x.IsActive)
                .Select(x => new UsersModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    MobileNo = x.MobileNo,
                    Email = x.Email,
                    Role = x.Role.Name,
                    SysAdmin = (x.SysAdmin.HasValue && x.SysAdmin.Value ? "Yes" : "No"),
                    IsActive = x.IsActive,
                    AddedDate = x.AddedDate,
                    AddedBy = x.AddedBy.FirstName + " " + x.AddedBy.LastName,
                    ModifiedDate = x.ModifiedDate,
                    ModifiedBy = x.ModifiedBy.FirstName + "" + x.ModifiedBy.LastName
                }).ToList();
            return users;
        }

        [HttpGet("{id:int}")]
        public UserModel GetById(int id)
        {
            var user = dbContext.Users
                .Where(x => x.Id == id)
                .Select(x => new UserModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    MobileNo = x.MobileNo,
                    Email = x.Email,
                    RoleId = x.RoleId,
                    SysAdmin = x.SysAdmin,
                    IsActive = x.IsActive
                }).FirstOrDefault();
            return user;
        }

        [HttpPost]
        public bool Post(UserModel userModel)
        {
            var user = dbContext.Users.Where(x => x.Username == userModel.Username).FirstOrDefault();

            if(user != null)
                return false;
            else
            {
                user = new User
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Username = userModel.Username,
                    Password = userModel.Password,
                    MobileNo = userModel.MobileNo,
                    Email = userModel.Email,
                    RoleId = userModel.RoleId,
                    SysAdmin = userModel.SysAdmin,
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedById = 1
                };

                dbContext.Users.Add(user);
                return dbContext.SaveChanges() > 0;
            }
        }

        [HttpPut("{id:int}")]
        public bool Put(int id, UserModel userModel)
        {
            var user = dbContext.Users.Where(x => x.Id == id).FirstOrDefault();

            if (user == null)
                return false;
            else
            {
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.MobileNo = userModel.MobileNo;
                user.Email = userModel.Email;
                user.RoleId = userModel.RoleId;
                user.SysAdmin = userModel.SysAdmin;
                user.IsActive = userModel.IsActive;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedById = 1;
                
                dbContext.Users.Update(user);
                return dbContext.SaveChanges() > 0;
            }
        }

        [HttpDelete("{id:int}")]
        public bool Delete(int id) 
        { 
            var user = dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) 
                return false;
            else
            {
                user.IsActive = false;
                return dbContext.SaveChanges() > 0;
            }
        }
    }
}
