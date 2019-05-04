using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milestone.Dapper
{
    public interface IRepositoryBase<T>
    {
        Task Insert(T entity, string insertSql);

        Task Update(T entity, string updateSql);

        Task Delete(string Id, string deleteSql);

        Task<List<T>> Select(string selectSql);

        Task<T> Detail(string Id, string detailSql);

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<List<T>> ExecQuerySP(string SPName);
    }
}
