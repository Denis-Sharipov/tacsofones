using TacsofonObj.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase
{
    public class GetTacsofonObjListUseCaseRequest : IUseCaseRequest<GetTacsofonObjListUseCaseResponse>
    {
        public string Platnost { get; private set; }
        public long? TacsofonObjId { get; private set; }

        private GetTacsofonObjListUseCaseRequest()
        { }

        public static GetTacsofonObjListUseCaseRequest CreateAllTacsofonObjRequest()
        {
            return new GetTacsofonObjListUseCaseRequest();
        }

        public static GetTacsofonObjListUseCaseRequest CreateTacsofonObjRequest(long tacsofonObjId)
        {
            return new GetTacsofonObjListUseCaseRequest() { TacsofonObjId = tacsofonObjId };
        }
        public static GetTacsofonObjListUseCaseRequest CreateAdresTacsofonObjRequest(string TacsofonObjs)
        {
            return new GetTacsofonObjListUseCaseRequest() { Platnost = TacsofonObjs };
        }
    }
}
