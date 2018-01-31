using KittleData.BaseClasses;
using KittleData.Business.Interfaces;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace KittleData.ViewModels
{
    public class RandomGifPageVm : BaseViewModel
    {
        private ImageSource _catGif;
        public ImageSource CatGif
        {
            get => _catGif;
            set
            {
                _catGif = value;
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

        public ICommand GoToSource { get; private set; }
        public ICommand RefreshGif { get; private set; }

        private readonly IGifService _gifService;
        public RandomGifPageVm(IGifService gifService)
        {
            _gifService = gifService;
            GoToSource = new Command(OpenSourcePage);
            RefreshGif = new Command(GetRandomGif);
            GetRandomGif();
        }

        private async void GetRandomGif()
        {
            IsBusy = true;

            var model = await _gifService.GetRandomGif();
            CatGif = ImageSource.FromStream(() => new MemoryStream(model.Gif));
            Source = model.SourceUrl;

            IsBusy = false;
        }

        private void OpenSourcePage()
        {
            Device.OpenUri(Source);
        }
    }
}
