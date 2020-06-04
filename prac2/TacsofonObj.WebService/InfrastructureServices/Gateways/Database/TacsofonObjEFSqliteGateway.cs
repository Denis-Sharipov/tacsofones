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

        public TacsofonObjEFSqliteGateway(TacsofonObjContext TacsofonObjContext)
            => _tacsofonObjContext = TacsofonObjContext;

        public async Task<tacsofonObj> GetTacsofonObj(long id)
           => await _tacsofonObjContext.TacsofonObjs.Where(b => b.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<tacsofonObj>> GetAllTacsofonObjs()
            => await _tacsofonObjContext.TacsofonObjs.ToListAsync();
          
        public async Task<IEnumerable<tacsofonObj>> QueryTacsofonObjs(Expression<Func<tacsofonObj, bool>> filter)
            => await _tacsofonObjContext.TacsofonObjs.Where(filter).ToListAsync();

        public async Task AddTacsofonObj(tacsofonObj tacsofonObj)
        {
            _tacsofonObjContext.TacsofonObjs.Add(tacsofonObj);
            await _tacsofonObjContext.SaveChangesAsync();
        }

        public async Task UpdateTacsofonObj(tacsofonObj tacsofonObj)
        {
            _tacsofonObjContext.Entry(tacsofonObj).State = EntityState.Modified;
            await _tacsofonObjContext.SaveChangesAsync();
        }

        public async Task RemoveTacsofonObj(tacsofonObj tacsofonObj)
        {
            _tacsofonObjContext.TacsofonObjs.Remove(tacsofonObj);
            await _tacsofonObjContext.SaveChangesAsync();
        }

    }
}
