using KittleData.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KittleData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomGifPage : ContentPage
    {
        public RandomGifPage()
        {
            InitializeComponent();
            BindingContext = new RandomGifPageVm();
        }
    }
}