using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetPlatnostListUseCase
{
    public class PlatnostCriteria : ICriteria<tacsofonObj>
    {
        public string Platnost { get; }

        public PlatnostCriteria (string platnost)
            => Platnost = platnost;

        public Expression<Func<tacsofonObj, bool>> Filter
            => (b => b.Oplata == Platnost);
    }
}
