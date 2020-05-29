using TacsofonObj.ApplicationServices.Ports.Gateways.Database;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TacsofonObj.ApplicationServices.Repositories
{
    public class DbTacsofonObjRepository : IReadOnlyTacsofonObjRepository,
                                     ITacsofonObjRepository
    {
        private readonly ITacsofonObjDatabaseGateway _databaseGateway;

        public DbTacsofonObjRepository(ITacsofonObjDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<DomainObjects.TacsofonObj> GetTacsofonObj(long id)
            => await _databaseGateway.GetTacsofonObj(id);

        public async Task<IEnumerable<DomainObjects.TacsofonObj>> GetAllTacsofonObjs()
            => await _databaseGateway.GetAllTacsofonObj();

        public async Task<IEnumerable<DomainObjects.TacsofonObj>> QueryTacsofonObj(ICriteria<DomainObjects.TacsofonObj> criteria)
            => await _databaseGateway.QueryTacsofonObj(criteria.Filter);

        public async Task AddTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
            => await _databaseGateway.AddTacsofonObj(tacsofonObj);

        public async Task RemoveTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
            => await _databaseGateway.RemoveTacsofonObj(tacsofonObj);

        public async Task UpdateTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
            => await _databaseGateway.UpdateTacsofonObj(tacsofonObj);
    }
}
