using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacsofonObj.DomainObjects;
using TacsofonObj.ApplicationServices.GetPlatnostListUseCase;
using TacsofonObj.InfrastructureServices.Presenters;

namespace TacsofonObj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TacsofonObjsController : ControllerBase
    {
        private readonly ILogger<TacsofonObjsController> _logger;
        private readonly IGetTacsofonObjListUseCase _getTacsofonObjListUseCase;

        public TacsofonObjsController(ILogger<TacsofonObjsController> logger,
                                IGetTacsofonObjListUseCase getTacsofonObjListUseCase)
        {
            _logger = logger;
            _getTacsofonObjListUseCase = getTacsofonObjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTacsofonObjs()
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAllTacsofonObjsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{tacsofonObjId}")]
        public async Task<ActionResult> GetTacsofonObj(long tacsofonObjId)
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateTacsofonObjRequest(tacsofonObjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("platnost/{platnost}")]
        public async Task<ActionResult> GetplatnostTacsofonObjs(string platnost)
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateTacsofonObjsRequest(platnost), presenter);
            return presenter.ContentResult;
        }
    }
}
