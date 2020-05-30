using TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase;
using System.Net;
using Newtonsoft.Json;
using TacsofonObj.ApplicationServices.Ports;

namespace TacsofonObj.InfrastructureServices.Presenters
{
    public class TacsofonObjListPresenter : IOutputPort<GetTacsofonObjListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public TacsofonObjListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetTacsofonObjListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.TacsofonObj) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
