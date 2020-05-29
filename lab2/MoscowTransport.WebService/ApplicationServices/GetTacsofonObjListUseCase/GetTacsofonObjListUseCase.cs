using System.Threading.Tasks;
using System.Collections.Generic;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using TacsofonObj.ApplicationServices.Ports;

namespace TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase
{
    public class GetTacsofonObjListUseCase : IGetTacsofonObjListUseCase
    {
        private readonly IReadOnlyTacsofonObjRepository _readOnlyTacsofonObjRepository;

        public GetTacsofonObjListUseCase(IReadOnlyTacsofonObjRepository readOnlyTacsofonObjRepository) 
            => _readOnlyTacsofonObjRepository = readOnlyTacsofonObjRepository;

        public async Task<bool> Handle(GetTacsofonObjListUseCaseRequest request, IOutputPort<GetTacsofonObjListUseCaseResponse> outputPort)
        {
            IEnumerable<DomainObjects.TacsofonObj> tacsofonObjs = null;
            if (request.TacsofonObjId != null)
            {
                var tacsofonObj = await _readOnlyTacsofonObjRepository.GetTacsofonObj(request.TacsofonObjId.Value);
                tacsofonObjs = (tacsofonObj != null) ? new List<DomainObjects.TacsofonObj>() { tacsofonObj } : new List<DomainObjects.TacsofonObj>();
                
            }
            else if (request.Platnost != null)
            {
                tacsofonObjs = await _readOnlyTacsofonObjRepository.QueryTacsofonObj(new PlatnostCriteria(request.Platnost));
            }
            else
            {
                tacsofonObjs = await _readOnlyTacsofonObjRepository.GetAllTacsofonObjs();
            }
            outputPort.Handle(new GetTacsofonObjListUseCaseResponse(tacsofonObjs));
            return true;
        }
    }
}
