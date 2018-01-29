using Autofac;
using KittleData.Business.Interfaces;
using KittleData.Business.Services;
using KittleData.ViewModels;
using KittleData.Views;
using Xamarin.Forms;

namespace KittleData
{
    public partial class App : Application
	{
        public static IContainer Container;
		public App ()
		{
            ResolveContainer();
			InitializeComponent();
            MainPage = new HomePage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void ResolveContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HomePageVm>().SingleInstance();
            builder.RegisterType<FactService>().As<IFactService>().InstancePerLifetimeScope();
            Container = builder.Build();
        }
	}
}
