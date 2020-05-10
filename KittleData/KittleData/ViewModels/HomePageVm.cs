using KittleData.Models;
using KittleData.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace KittleData.ViewModels
{
    public class HomePageVm : BaseViewModel
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

        private Uri _source;
        public Uri Source
        {
            get => _source;
            set
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshFact { get; private set; }
        public ICommand GoToSource { get; private set; }
        public ICommand RefreshGif { get; private set; }

        private readonly FactService _factService;
        private readonly GifService _gifService;

        public HomePageVm()
        {
            _factService = new FactService();
            _gifService = new GifService();

            RefreshFact = new AsyncCommand(GetCatFact);
            GoToSource = new AsyncCommand(OpenSourcePage);
            RefreshGif = new AsyncCommand(GetRandomGif);

            RefreshGif.Execute(null);
            RefreshFact.Execute(null);
        }

        private async Task GetCatFact()
        {
            var newFact = await _factService.GetRandomCatFact();
            CatFact = newFact?.Data.FirstOrDefault() ?? new CatFact();
        }

        private async Task GetRandomGif()
        {
            IsBusy = true;

            var model = await _gifService.GetRandomGif();
            Source = model.SourceUrl;

            IsBusy = false;
        }

        private async Task OpenSourcePage() =>
            await Launcher.OpenAsync(Source);
    }
}
