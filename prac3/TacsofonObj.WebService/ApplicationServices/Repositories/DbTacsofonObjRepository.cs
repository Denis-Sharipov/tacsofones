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

        public async Task<tacsofonObj> GetTacsofonObj(long id)
            => await _databaseGateway.GetTacsofonObj(id);

        public async Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
            => await _databaseGateway.GetAllTacsofonObjs();

        public async Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria)
            => await _databaseGateway.QueryTacsofonObjs(criteria.Filter);

        public async Task AddTacsofonObj(tacsofonObj tacsofonObj)
            => await _databaseGateway.AddTacsofonObj(tacsofonObj);

        public async Task RemoveTacsofonObj(tacsofonObj tacsofonObj)
            => await _databaseGateway.RemoveTacsofonObj(tacsofonObj);

        public async Task UpdateTacsofonObj(tacsofonObj tacsofonObj)
            => await _databaseGateway.UpdateTacsofonObj(tacsofonObj);
    }
}
