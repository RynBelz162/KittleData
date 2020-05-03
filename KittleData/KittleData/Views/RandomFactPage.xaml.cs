using KittleData.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KittleData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomFactPage : ContentPage
    {
        public RandomFactPage()
        {
            InitializeComponent();
            BindingContext = new RandomFactPageVm();
            
        }
    }
}