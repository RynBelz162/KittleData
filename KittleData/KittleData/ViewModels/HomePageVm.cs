using KittleData.Business.Models;
using KittleData.Business.Services;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace KittleData.ViewModels
{
    class HomePageVm : BaseViewModel
    {
        private CatFact _catFact;
        public CatFact CatFact
        {
            get => _catFact;
            set
            {
                _catFact = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshFact { get; private set; }

        private readonly FactService _factService;
        public HomePageVm()
        {
            _factService = new FactService();
            RefreshFact = new Command(GetCatFact);
            GetCatFact();
        }

        private async void GetCatFact()
        {
            IsBusy = true;
            var newFact = await _factService.GetRandomCatFact();
            CatFact = newFact.Data.First() ?? new CatFact();
            IsBusy = false;
        }
    }
}
