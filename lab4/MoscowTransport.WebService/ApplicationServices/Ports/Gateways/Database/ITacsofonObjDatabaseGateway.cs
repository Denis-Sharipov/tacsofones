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
        Task AddTacsofonObj(DomainObjects.TacsofonObj tacsofonObj);

        Task RemoveTacsofonObj(DomainObjects.TacsofonObj tacsofonObj);

        Task UpdateTacsofonObj(DomainObjects.TacsofonObj tacsofonObj);

        Task<DomainObjects.TacsofonObj> GetTacsofonObj(long id);

        Task<IEnumerable<DomainObjects.TacsofonObj>> GetAllTacsofonObj();

        Task<IEnumerable<DomainObjects.TacsofonObj>> QueryTacsofonObj(Expression<Func<DomainObjects.TacsofonObj, bool>> filter);

    }
}
