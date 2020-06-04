using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TacsofonObj.DomainObjects.Repositories
{
    public abstract class ReadOnlyTacsofonObjRepositoryDecorator : IReadOnlyTacsofonObjRepository
    {
        private readonly IReadOnlyTacsofonObjRepository _tacsofonObjRepository;

        public ReadOnlyTacsofonObjRepositoryDecorator(IReadOnlyTacsofonObjRepository tacsofonObjRepository)
        {
            _tacsofonObjRepository = tacsofonObjRepository;
        }

        public virtual async Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
        {
            return await _tacsofonObjRepository?.GetAllTacsofonObjs();
        }

        public virtual async Task<tacsofonObj> GetTacsofonObj(long id)
        {
            return await _tacsofonObjRepository?.GetTacsofonObj(id);
        }

        public virtual async Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria)
        {
            return await _tacsofonObjRepository?.QueryTacsofonObjs(criteria);
        }
    }
}
