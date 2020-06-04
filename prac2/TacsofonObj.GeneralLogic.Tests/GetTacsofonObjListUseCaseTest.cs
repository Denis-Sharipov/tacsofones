using TacsofonObj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using TacsofonObj.ApplicationServices.GetPlatnostListUseCase;
using System.Linq.Expressions;
using TacsofonObj.ApplicationServices.Ports;
using TacsofonObj.DomainObjects.Ports;
using TacsofonObj.ApplicationServices.Repositories;

namespace TacsofonObj.WebService.Core.Tests
{
    public class GetTacsofonObjListUseCaseTest
    {
        private InMemoryTacsofonObjRepository CreateTacsofonObjRepository()
        {
            var repo = new InMemoryTacsofonObjRepository(new List<tacsofonObj> {
                new tacsofonObj { Id = 1, Oplata = "карта", Name = "Таксофон № 1449"},
                new tacsofonObj { Id = 2, Oplata = "карта", Name = "Таксофон № 1499"},
                new tacsofonObj { Id = 3, Oplata = "карта", Name = "Таксофон № 1476"},
                new tacsofonObj { Id = 4, Oplata = "карта", Name = "Таксофон № 1857"},
            });
            return repo;
        }
        [Fact]
        public void TestGetAllTacsofonObj()
        {
            var useCase = new GetTacsofonObjListUseCase(CreateTacsofonObjRepository());
            var outputPort = new OutputPort();
                        
            Assert.True(useCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAllTacsofonObjsRequest(), outputPort).Result);
            Assert.Equal<int>(4, outputPort.TacsofonObjs.Count());
            Assert.Equal(new long[] { 1, 2, 3, 4 }, outputPort.TacsofonObjs.Select(mp => mp.Id));
        }

        [Fact]
        public void TestGetAllTacsofonObjsFromEmptyRepository()
        {
            var useCase = new GetTacsofonObjListUseCase(new InMemoryTacsofonObjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAllTacsofonObjsRequest(), outputPort).Result);
            Assert.Empty(outputPort.TacsofonObjs);
        }

        [Fact]
        public void TestGetTacsofonObj()
        {
            var useCase = new GetTacsofonObjListUseCase(CreateTacsofonObjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTacsofonObjListUseCaseRequest.CreateTacsofonObjRequest(2), outputPort).Result);
            Assert.Single(outputPort.TacsofonObjs, pn => 2 == pn.Id);
        }

        [Fact]
        public void TestTryGetNotExistingTacsofonObj()
        {
            var useCase = new GetTacsofonObjListUseCase(CreateTacsofonObjRepository());
            var outputPort = new OutputPort();

            Assert.True(useCase.Handle(GetTacsofonObjListUseCaseRequest.CreateTacsofonObjRequest(999), outputPort).Result);
            Assert.Empty(outputPort.TacsofonObjs);
        }
      
    }

    class OutputPort : IOutputPort<GetTacsofonObjListUseCaseResponse>
    {
        public IEnumerable<tacsofonObj> TacsofonObjs { get; private set; }

        public void Handle(GetTacsofonObjListUseCaseResponse response)
        {
            TacsofonObjs = response.TacsofonObjs;
        }
    }
}
