using TacsofonObj.DomainObjects;
using TacsofonObj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetPlatnostListUseCase
{
    public class GetTacsofonObjListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<tacsofonObj> TacsofonObjs { get; }

        public GetTacsofonObjListUseCaseResponse(IEnumerable<tacsofonObj> tacsofonObjs) => TacsofonObjs = tacsofonObjs;
    }
}
