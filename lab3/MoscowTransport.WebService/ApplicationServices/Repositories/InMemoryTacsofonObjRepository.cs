using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TacsofonObj.ApplicationServices.Repositories
{
    public class InMemoryTacsofonObjRepository : IReadOnlyTacsofonObjRepository,
                                             ITacsofonObjRepository 
    {
        private readonly List<DomainObjects.TacsofonObj> _tacsofonObjs = new List<DomainObjects.TacsofonObj>();

        public InMemoryTacsofonObjRepository(IEnumerable<DomainObjects.TacsofonObj> tacsofonObjs = null)
        {
            if (tacsofonObjs != null)
            {
                _tacsofonObjs.AddRange(tacsofonObjs);
            }
        }

        public Task AddTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
        {
            _tacsofonObjs.Add(tacsofonObj);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DomainObjects.TacsofonObj>> GetAllTacsofonObjs()
        {
            return Task.FromResult(_tacsofonObjs.AsEnumerable());
        }

        public Task<DomainObjects.TacsofonObj> GetTacsofonObj(long id)
        {
            return Task.FromResult(_tacsofonObjs.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<DomainObjects.TacsofonObj>> QueryTacsofonObj(ICriteria<DomainObjects.TacsofonObj> criteria)
        {
            return Task.FromResult(_tacsofonObjs.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
        {
            _tacsofonObjs.Remove(tacsofonObj);
            return Task.CompletedTask;
        }

        public Task UpdateTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
        {
            var foundTacsofonObj = GetTacsofonObj(tacsofonObj.Id).Result;
            if (foundTacsofonObj == null)
            {
                AddTacsofonObj(tacsofonObj);
            }
            else
            {
                if (foundTacsofonObj != tacsofonObj)
                {
                    _tacsofonObjs.Remove(foundTacsofonObj);
                    _tacsofonObjs.Add(tacsofonObj);
                }
            }
            return Task.CompletedTask;
        }
    }
}
