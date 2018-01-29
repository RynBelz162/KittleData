using Autofac;
using Xamarin.Forms;

namespace KittleData.BaseClasses
{
    public class ViewPage<T> : ContentPage where T: BaseViewModel
    {
        readonly T _viewModel;
        public T ViewModel
        {
            get { return _viewModel; }
        }

        public ViewPage()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _viewModel = App.Container.Resolve<T>();
            }
            BindingContext = _viewModel;
        }
    }
}
