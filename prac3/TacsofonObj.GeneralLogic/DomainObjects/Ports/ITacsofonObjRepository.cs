using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TacsofonObj.DomainObjects.Ports
{
    public interface IReadOnlyTacsofonObjRepository
    {
        Task<tacsofonObj> GetTacsofonObj(long id);

        Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs();

        Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria);

    }

    public interface ITacsofonObjRepository
    {
        Task AddTacsofonObj(tacsofonObj tacsofonObj);

        Task RemoveTacsofonObj(tacsofonObj tacsofonObj);

        Task UpdateTacsofonObj(tacsofonObj tacsofonObj);
    }
}
