using TacsofonObj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TacsofonObj.ApplicationServices.Ports.Gateways.Database
{
    public interface ITacsofonObjDatabaseGateway
    {
        Task AddTacsofonObj(tacsofonObj tacsofonObj);

        Task RemoveTacsofonObj(tacsofonObj tacsofonObj);

        Task UpdateTacsofonObj(tacsofonObj tacsofonObj);

        Task<tacsofonObj> GetTacsofonObj(long id);

        Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs();

        Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(Expression<Func<tacsofonObj, bool>> filter);

    }
}
