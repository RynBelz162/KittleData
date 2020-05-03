using KittleData.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace KittleData.ViewModels
{
    public class RandomGifPageVm : BaseViewModel
    {
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

        public ICommand GoToSource { get; private set; }
        public ICommand RefreshGif { get; private set; }

        private readonly GifService _gifService;
        public RandomGifPageVm()
        {
            _gifService = new GifService();
            GoToSource = new AsyncCommand(OpenSourcePage);
            RefreshGif = new AsyncCommand(GetRandomGif);
            RefreshGif.Execute(null);
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
