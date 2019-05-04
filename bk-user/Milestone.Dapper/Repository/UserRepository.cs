using Dapper;
using Milestone.Dapper.Entities;
using Milestone.Dapper.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Milestone.Dapper.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public async Task DeleteUser(string Id)
        {
            string deleteSql = "DELETE FROM [dbo].[Users] WHERE Id=@Id";
            await Delete(Id, deleteSql);
        }

        public string ExecExecQueryParamSP(string spName, string name, string Id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", name, DbType.String, ParameterDirection.Output, 100);
                parameters.Add("@Id", Id, DbType.String, ParameterDirection.Input);
                conn.Execute(spName, parameters, null, null, CommandType.StoredProcedure);
                string strUserName = parameters.Get<string>("@UserName");
                return strUserName;
            }
        }

        public async Task<Users> GetUserDetail(string Id)
        {
            string detailSql = @"select veh_no as [UserName], [password] as [Password], veh_abbr as [Id], drv_code as [Driver] from vehmst where coycode = 'GEL' and veh_abbr = '" + Id + "'";
            //@"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users] WHERE Id=@Id";
            return await Detail(Id, detailSql);
        }

        public async Task<List<Users>> GetUsers()
        {
            string selectSql = @"select veh_no as [UserName], [password] as [Password], veh_abbr as [Id], drv_code as [Driver] from vehmst where coycode = 'GEL'";
            //@"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users]";
            return await Select(selectSql);
        }

        public async Task PostUser(Users entity)
        {
            string insertSql = @"INSERT INTO [dbo].[Users](Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete) VALUES(@Id, @UserName, @Password, @Gender, @Birthday, @CreateDate, @IsDelete)";
            await Insert(entity, insertSql);
        }

        public async Task PutUser(Users entity)
        {
            string updateSql = "UPDATE [dbo].[Users] SET UserName=@UserName, Password=@Password, Gender=@Gender, Birthday=@Birthday, CreateDate=@CreateDate, IsDelete=@IsDelete WHERE Id=@Id";
            await Update(entity, updateSql);
        }
    }
}
