using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using TacsofonObj.ApplicationServices.GetPlatnostListUseCase;
using TacsofonObj.ApplicationServices.Ports;
using TacsofonObj.DomainObjects;

namespace TacsofonObj.DesktopClient.InfrastructureServices.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IGetTacsofonObjListUseCase _getTacsofonObjListUseCase;

        public MainViewModel(IGetTacsofonObjListUseCase getTacsofonObjListUseCase)
            => _getTacsofonObjListUseCase = getTacsofonObjListUseCase;

        private Task<bool> _loadingTask;
        private tacsofonObj _currentTacsofonObj;
        private ObservableCollection<tacsofonObj> _tacsofonObjs;

        public event PropertyChangedEventHandler PropertyChanged;

        public tacsofonObj CurrentTacsofonObj
        {
            get => _currentTacsofonObj; 
            set
            {
                if (_currentTacsofonObj != value)
                {
                    _currentTacsofonObj = value;
                    OnPropertyChanged(nameof(CurrentTacsofonObj));
                }
            }
        }

        private async Task<bool> LoadTacsofonObjs()
        {
            var outputPort = new OutputPort();
            bool result = await _getTacsofonObjListUseCase.Handle(GetTacsofonObjListUseCaseRequest.CreateAllTacsofonObjsRequest(), outputPort);
            if (result)
            {
                TacsofonObjs = new ObservableCollection<tacsofonObj>(outputPort.TacsofonObjs);
            }
            return result;
        }

        public ObservableCollection<tacsofonObj> TacsofonObjs
        {
            get 
            {
                if (_loadingTask == null)
                {
                    _loadingTask = LoadTacsofonObjs();
                }
                
                return _tacsofonObjs; 
            }
            set
            {
                if (_tacsofonObjs != value)
                {
                    _tacsofonObjs = value;
                    OnPropertyChanged(nameof(TacsofonObjs));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class OutputPort : IOutputPort<GetTacsofonObjListUseCaseResponse>
        {
            public IEnumerable<tacsofonObj> TacsofonObjs { get; private set; }

            public void Handle(GetTacsofonObjListUseCaseResponse response)
            {
                if (response.Success)
                {
                    TacsofonObjs = new ObservableCollection<tacsofonObj>(response.TacsofonObjs);
                }
            }
        }
    }
}
