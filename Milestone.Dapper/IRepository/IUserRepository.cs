using Milestone.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milestone.Dapper.IRepository
{
    public interface IUserRepository : IRepositoryBase<Users> 
    {
        #region 扩展的dapper操作

        //加一个带参数的存储过程
        string ExecExecQueryParamSP(string spName, string name, string Id);

        Task<List<Users>> GetUsers();

        Task PostUser(Users entity);

        Task PutUser(Users entity);

        Task DeleteUser(string Id);

        //Task<List<Users>> GetUserDetail(string Id);
        Task<List<Users>> GetUserDetail(string UserId, string Password);
        //Users GetUserProfile<Users>(string Id);

        #endregion
    }
}
