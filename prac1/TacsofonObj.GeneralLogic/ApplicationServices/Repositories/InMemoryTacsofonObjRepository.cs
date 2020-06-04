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
        private readonly List<tacsofonObj> _tacsofonObjs = new List<tacsofonObj>();

        public InMemoryTacsofonObjRepository(IEnumerable<tacsofonObj> tacsofonObjs = null)
        {
            if (tacsofonObjs != null)
            {
                _tacsofonObjs.AddRange(tacsofonObjs);
            }
        }

        public Task AddTacsofonObj(tacsofonObj tacsofonObj)
        {
            _tacsofonObjs.Add(tacsofonObj);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
        {
            return Task.FromResult(_tacsofonObjs.AsEnumerable());
        }

        public Task<tacsofonObj> GetTacsofonObj(long id)
        {
            return Task.FromResult(_tacsofonObjs.Where(pn => pn.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(ICriteria<tacsofonObj> criteria)
        {
            return Task.FromResult(_tacsofonObjs.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveTacsofonObj(tacsofonObj tacsofonObj)
        {
            _tacsofonObjs.Remove(tacsofonObj);
            return Task.CompletedTask;
        }

        public Task UpdateTacsofonObj(tacsofonObj tacsofonObj)
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
