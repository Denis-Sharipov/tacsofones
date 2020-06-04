using System.Threading.Tasks;
using System.Collections.Generic;
using TacsofonObj.DomainObjects;
using TacsofonObj.DomainObjects.Ports;
using TacsofonObj.ApplicationServices.Ports;

namespace TacsofonObj.ApplicationServices.GetPlatnostListUseCase
{
    public class GetTacsofonObjListUseCase : IGetTacsofonObjListUseCase
    {
        private readonly IReadOnlyTacsofonObjRepository _readOnlyTacsofonObjRepository;

        public GetTacsofonObjListUseCase(IReadOnlyTacsofonObjRepository readOnlyTacsofonObjRepository) 
            => _readOnlyTacsofonObjRepository = readOnlyTacsofonObjRepository;
        
        public async Task<bool> Handle(GetTacsofonObjListUseCaseRequest request, IOutputPort<GetTacsofonObjListUseCaseResponse> outputPort)
        {
            IEnumerable<tacsofonObj> tacsofonObjs = null;
            if (request.TacsofonObjId != null)
            {
                var tacsofonObj = await _readOnlyTacsofonObjRepository.GetTacsofonObj(request.TacsofonObjId.Value);
                tacsofonObjs = (tacsofonObj != null) ? new List<tacsofonObj>() { tacsofonObj } : new List<tacsofonObj>();
                
            }
            else if (request.Platnost != null)
            {
                tacsofonObjs = await _readOnlyTacsofonObjRepository.QueryTacsofonObjs(new PlatnostCriteria(request.Platnost));
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
