using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacsofonObj.DomainObjects;
using TacsofonObj.ApplicationServices.GetTacsofonObjListUseCase;
using TacsofonObj.InfrastructureServices.Presenters;

namespace TacsofonObj.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TacsofonObjController : ControllerBase
    {
        private readonly ILogger<TacsofonObjController> _logger;
        private readonly IGetTacsofonObjListUseCase _getTacsofonObjListUseCase;

        public TacsofonObjController(ILogger<TacsofonObjController> logger,
                                IGetTacsofonObjListUseCase getTacsofonObjListUseCase)
        {
            _logger = logger;
            _getTacsofonObjListUseCase = getTacsofonObjListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTacsofonObj()
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAllTacsofonObjRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{tacsofonObjId}")]
        public async Task<ActionResult> GetTacsofonObj(long tacsofonObjId)
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateTacsofonObjRequest(tacsofonObjId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("MetroLines/{metroLine}")]
        public async Task<ActionResult> GetMetroLineFilter(string metroLine)
        {
            var presenter = new TacsofonObjListPresenter();
            await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAdresTacsofonObjRequest(metroLine), presenter);
            return presenter.ContentResult;
        }
    }
}
