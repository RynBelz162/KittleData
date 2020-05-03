using KittleData.Models;
using KittleData.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KittleData.ViewModels
{
    public class RandomFactPageVm : BaseViewModel
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

        public RandomFactPageVm()
        {
            _factService = new FactService();
            RefreshFact = new AsyncCommand(GetCatFact);
            RefreshFact.Execute(null);
        }

        private async Task GetCatFact()
        {
            IsBusy = true;
            var newFact = await _factService.GetRandomCatFact();
            CatFact = newFact.Data.First() ?? new CatFact();
            IsBusy = false;
        }
    }
}
