using TacsofonObj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetPlatnostListUseCase
{
    public class GetTacsofonObjListUseCaseRequest : IUseCaseRequest<GetTacsofonObjListUseCaseResponse>
    {
        public string Platnost { get; private set; }
        public long? TacsofonObjId { get; private set; }

        private GetTacsofonObjListUseCaseRequest()
        { }

        public static GetTacsofonObjListUseCaseRequest CreateAllTacsofonObjsRequest()
        {
            return new GetTacsofonObjListUseCaseRequest();
        }

        public static GetTacsofonObjListUseCaseRequest CreateTacsofonObjRequest(long tacsofonObjId)
        {
            return new GetTacsofonObjListUseCaseRequest() { TacsofonObjId = tacsofonObjId };
        }
        public static GetTacsofonObjListUseCaseRequest CreateTacsofonObjsRequest(string platnost)
        {
            return new GetTacsofonObjListUseCaseRequest() { Platnost = platnost };
        }
    }
}
