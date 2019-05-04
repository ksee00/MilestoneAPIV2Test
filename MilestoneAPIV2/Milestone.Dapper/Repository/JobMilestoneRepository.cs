using Dapper;
using Milestone.Dapper.Entities;
using Milestone.Dapper.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Milestone.Dapper.Repository
{
    public class JobMilestoneRepository : RepositoryBase<JobMilestone>, IJobMilestoneRespository
    {

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

        // ----------------------------------------
        public async Task<List<JobMilestone>> GetOutbundJobs(string Id)
        {
            string selectSql = @"WITH groups AS (SELECT jm.id, jm.veh_no, jm.jobno, jm.cont_no, jm.mile_stage, jm.mile_name, jm.mile_code, jm.location_from, jm.location_to,ROW_NUMBER() OVER (PARTITION BY jm.veh_no, jm.jobno, jm.cont_no ORDER BY jm.veh_no, jm.jobno, jm.cont_no, jm.mile_stage) AS [ROW NUMBER] FROM jobmilemst jm left join milemst mm on mm.mile_code = jm.mile_code where mm.active_flag ='Y' and (jm.status_flag != 'C' or jm. status_flag is null) and (jm.mile_stage in ('OPM','OPMR','OPMA')) and jm.veh_no = '" + Id + "') SELECT * FROM groups WHERE groups.[ROW NUMBER] = 1";
            return await Select(selectSql);
        }

        public async Task<List<JobMilestone>> GetInbundJobs(string Id)
        {
            string selectSql = @"WITH groups AS (SELECT jm.id, jm.veh_no, jm.jobno, jm.cont_no, jm.mile_stage, jm.mile_name, jm.mile_code, jm.location_from, jm.location_to,ROW_NUMBER() OVER (PARTITION BY jm.veh_no, jm.jobno, jm.cont_no ORDER BY jm.veh_no, jm.jobno, jm.cont_no, jm.mile_stage) AS [ROW NUMBER] FROM jobmilemst jm left join milemst mm on mm.mile_code = jm.mile_code where mm.active_flag ='Y' and (jm.status_flag != 'C' or jm. status_flag is null) and (jm.mile_stage in ('PM','PMR','PMA')) and jm.veh_no = '" + Id + "') SELECT * FROM groups WHERE groups.[ROW NUMBER] = 1";
            return await Select(selectSql);
        }

        public async Task CompleteIndoundTask(string id, DateTime completeDate)
        {
            string updateSql = "UPDATE [dbo].[jobmilemst] SET status_flag = 'C', mile_date = '"+ completeDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' WHERE id = '" + id + "'";
            await UpdateSQL(updateSql);
        }
    }
}
