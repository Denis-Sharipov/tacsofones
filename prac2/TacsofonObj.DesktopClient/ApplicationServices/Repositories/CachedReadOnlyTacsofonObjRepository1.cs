using TacsofonObj.ApplicationServices.Ports.Cache;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using TacsofonObj.DomainObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TacsofonObj.ApplicationServices.Repositories
{
    public class CachedReadOnlyTacsofonObjRepository : ReadOnlyTacsofonObjRepositoryDecorator
    {
        private readonly IDomainObjectsCache<tacsofonObj> _tacsofonObjsCache;

        public CachedReadOnlyTacsofonObjRepository(IReadOnlyTacsofonObjRepository tacsofonObjRepository, 
                                             IDomainObjectsCache<tacsofonObj> tacsofonObjsCache)
            : base(tacsofonObjRepository)
            => _tacsofonObjsCache = tacsofonObjsCache;

        public async override Task<tacsofonObj> GetTacsofonObj(long id)
            => _tacsofonObjsCache.GetObject(id) ?? await base.GetTacsofonObj(id);

        public async override Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
            => _tacsofonObjsCache.GetObjects() ?? await base.GetAllTacsofonObjs();

        public async override Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria)
            => _tacsofonObjsCache.GetObjects()?.Where(criteria.Filter.Compile()) ?? await base.QueryTacsofonObjs(criteria);

    }
}
