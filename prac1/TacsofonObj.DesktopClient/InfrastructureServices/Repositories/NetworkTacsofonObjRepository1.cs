using TacsofonObj.ApplicationServices.Ports.Cache;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TacsofonObj.InfrastructureServices.Repositories
{
    public class NetworkTacsofonObjRepository : NetworkRepositoryBase, IReadOnlyTacsofonObjRepository
    {
        private readonly IDomainObjectsCache<tacsofonObj> _tacsofonObjCache;

        public NetworkTacsofonObjRepository(string host, ushort port, bool useTls, IDomainObjectsCache<tacsofonObj> tacsofonObjCache)
            : base(host, port, useTls)
            => _tacsofonObjCache = tacsofonObjCache;

        public async Task<tacsofonObj> GetTacsofonObj(long id)
            => CacheAndReturn(await ExecuteHttpRequest<tacsofonObj>($"tacsofonObjs/{id}"));

        public async Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<tacsofonObj>>($"tacsofonObjs"), allObjects: true);

        public async Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria)
            => CacheAndReturn(await ExecuteHttpRequest<IEnumerable<tacsofonObj>>($"tacsofonObjs"), allObjects: true)
               .Where(criteria.Filter.Compile());


        private IEnumerable<tacsofonObj> CacheAndReturn(IEnumerable<tacsofonObj> tacsofonObjs, bool allObjects = false)
        {
            if (allObjects)
            {
                _tacsofonObjCache.ClearCache();
            }
            _tacsofonObjCache.UpdateObjects(tacsofonObjs, DateTime.Now.AddDays(1), allObjects);
            return tacsofonObjs;
        }

        private tacsofonObj CacheAndReturn(tacsofonObj tacsofonObj)
        {
            _tacsofonObjCache.UpdateObject(tacsofonObj, DateTime.Now.AddDays(1));
            return tacsofonObj;
        }
    }
}
