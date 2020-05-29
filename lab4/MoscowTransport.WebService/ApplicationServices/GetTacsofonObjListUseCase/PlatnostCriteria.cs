using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase
{
    public class PlatnostCriteria : ICriteria<DomainObjects.TacsofonObj>
    {
        public string Platnost { get; }      /*save filtration criteria*/

        public PlatnostCriteria(string platnost) /*get criteria and save as class member*/
            => Platnost = platnost;

        public Expression<Func<DomainObjects.TacsofonObj, bool>> Filter
            => (tacsofon => tacsofon.Platnost == Platnost); /*Filter*/
    }
}
