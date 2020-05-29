using TacsofonObj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TacsofonObj.ApplicationServices.Ports.Gateways.Database;

namespace TacsofonObj.InfrastructureServices.Gateways.Database
{
    public class TacsofonObjEFSqliteGateway : ITacsofonObjDatabaseGateway
    {
        private readonly TacsofonObjContext _tacsofonObjContext;

        public TacsofonObjEFSqliteGateway(TacsofonObjContext tacsofonObjContext)
            => _tacsofonObjContext = tacsofonObjContext;

        public async Task<DomainObjects.TacsofonObj> GetTacsofonObj(long id)
           => await _tacsofonObjContext.TacsofonObjs.FirstOrDefaultAsync();

        public async Task<IEnumerable<DomainObjects.TacsofonObj>> GetAllTacsofonObj()
            => await _tacsofonObjContext.TacsofonObjs.ToListAsync();
          
        public async Task<IEnumerable<DomainObjects.TacsofonObj>> QueryTacsofonObj(Expression<Func<DomainObjects.TacsofonObj, bool>> filter)
            => await _tacsofonObjContext.TacsofonObjs.Where(filter).ToListAsync();

        public async Task AddTacsofonObj(DomainObjects.TacsofonObj tacsofonObj)
        {
            _tacsofonObjContext.TacsofonObjs.Add(tacsofonObj);
            await _tacsofonObjContext.SaveChangesAsync();
        }

        public async Task UpdateTacsofonObj(DomainObjects.TacsofonObj tacsofonobj)
        {
            _tacsofonObjContext.Entry(tacsofonobj).State = EntityState.Modified;
            await _tacsofonObjContext.SaveChangesAsync();
        }

        public async Task RemoveTacsofonObj(DomainObjects.TacsofonObj tacsofonobj)
        {
            _tacsofonObjContext.TacsofonObjs.Remove(tacsofonobj);
            await _tacsofonObjContext.SaveChangesAsync();
        }


       
    }
}
