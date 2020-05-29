using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TacsofonObj.DomainObjects.Ports
{
    public interface IReadOnlyTacsofonObjRepository
    {
        Task<TacsofonObj> GetTacsofonObj(long id);

        Task<IEnumerable<TacsofonObj>> GetAllTacsofonObjs();

        Task<IEnumerable<TacsofonObj>> QueryTacsofonObj(ICriteria<TacsofonObj> criteria);

    }

    public interface ITacsofonObjRepository
    {
        Task AddTacsofonObj(TacsofonObj tacsofonObj);

        Task RemoveTacsofonObj(TacsofonObj tacsofonObj);

        Task UpdateTacsofonObj(TacsofonObj tacsofonObj);
    }
}
