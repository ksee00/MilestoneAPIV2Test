using Milestone.Dapper.Entities;
using Milestone.Dapper.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milestone.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        public UsersController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<JsonResult> GetUsers()
        {
            List<Users> list = await userRepository.GetUsers();
            return Json(list);
        }

        /// <summary>
        /// Get User Detail by user id
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<JsonResult> GetUserDetail(string UserId, string Password)
        //public IActionResult  GetUserDetail(string Id)
        {
            try
            {
                List<Users> user = await userRepository.GetUserDetail(UserId, Password);
                //List<Users> user = await userRepository.GetUserDetail(Id);
                return Json(user);
                //return Ok(user);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task PostUser(Users entity)
        {
            entity.Password = Dapper.Helpers.Encrypt.Md5(entity.Password).ToUpper();
            await userRepository.PostUser(entity);
        }

        /// <summary>
        /// Modify user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task PutUser(Users entity)
        {
            try
            {
                entity.Password = Dapper.Helpers.Encrypt.Md5(entity.Password).ToUpper();
                await userRepository.PutUser(entity);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteUser(string Id)
        {
            try
            {
                await userRepository.DeleteUser(Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}