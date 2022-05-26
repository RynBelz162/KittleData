using Microsoft.Maui.Controls;

namespace KittleData.Maui;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageVm viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
