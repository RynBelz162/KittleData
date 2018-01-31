using KittleData.BaseClasses;
using KittleData.ViewModels;
using Xamarin.Forms.Xaml;

namespace KittleData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomGifPage : ViewPage<RandomGifPageVm>
    {
        public RandomGifPage()
        {
            InitializeComponent();
        }
    }
}