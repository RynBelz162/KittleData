using Application = Microsoft.Maui.Controls.Application;

namespace KittleData.Maui;

public partial class App : Application
{
    public App(MainPage mainPage)
    {
        InitializeComponent();
        MainPage = mainPage;
    }
}
