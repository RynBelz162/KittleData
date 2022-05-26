using System;
using System.Linq;
using System.Threading.Tasks;
using KittleData.Maui.Services;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace KittleData.Maui;

[INotifyPropertyChanged]
public partial class MainPageVm
{
    [ObservableProperty]
    private string? _catFact;

    [ObservableProperty]
    private Uri? _source;

    [ObservableProperty]
    private bool _isBusy = false;

    private readonly FactService _factService;
    private readonly GifService _gifService;

    public MainPageVm(
        FactService factService,
        GifService gifService)
    {
        _factService = factService;
        _gifService = gifService;

        GetCatFactCommand.Execute(null);
        GetRandomGifCommand.Execute(null);
    }

    [ICommand]
    private async Task GetCatFact()
    {
        var newFact = await _factService.GetRandomCatFact();
        CatFact = newFact?.Data.FirstOrDefault()?.Fact;
    }

    [ICommand]
    private async Task GetRandomGif()
    {
        IsBusy = true;

        var model = await _gifService.GetRandomGif();
        Source = model.SourceUrl;

        IsBusy = false;
    }

    [ICommand]
    private async Task OpenSourcePage()
    {
        if (Source is null)
        {
            return;
        }

        _ = await Launcher.OpenAsync(Source);
    }
}