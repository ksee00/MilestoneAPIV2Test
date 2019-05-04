using Milestone.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milestone.Dapper.IRepository
{
    public interface IJobMilestoneRespository : IRepositoryBase<JobMilestone>
    {
        #region 扩展的dapper操作

        //加一个带参数的存储过程
        string ExecExecQueryParamSP(string spName, string name, string Id);

        Task<List<JobMilestone>> GetInbundJobs(string Id);

        Task<List<JobMilestone>> GetOutbundJobs(string Id);

        Task<List<JobMilestone>> GetPickupJobs(string Id);

        Task CompleteInboundTask(string id, DateTime completeDate);

        Task CompleteOutboundTask(string id, string veh_no, string cont_no, DateTime completeDate);

        //public Task Insert(JobMilestone entity, string insertSql)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Update(JobMilestone entity, string updateSql)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Delete(string Id, string deleteSql)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<JobMilestone>> Select(string selectSql)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<JobMilestone> Detail(string Id, string detailSql)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<JobMilestone>> ExecQuerySP(string SPName)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
