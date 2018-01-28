using KittleData.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KittleData.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        private readonly HomePageVm _vm;
		public HomePage ()
		{
            BindingContext = _vm = new HomePageVm();
			InitializeComponent ();
		}
	}
}