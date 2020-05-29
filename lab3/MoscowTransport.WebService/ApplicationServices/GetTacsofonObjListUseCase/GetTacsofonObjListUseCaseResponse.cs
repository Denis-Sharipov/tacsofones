using TacsofonObj.DomainObjects;
using TacsofonObj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase
{
    public class GetTacsofonObjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<DomainObjects.TacsofonObj> TacsofonObj { get; }

        public GetTacsofonObjListUseCaseResponse(IEnumerable<DomainObjects.TacsofonObj> tacsofonObj) => TacsofonObj = tacsofonObj;
    }
}
