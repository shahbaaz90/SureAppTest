using Prism;
using Prism.Ioc;
using SureAppTest.ViewModels;
using SureAppTest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using SureAppTest.DataAccess.Factories;
using SureAppTest.Services;
using SureAppTest.DataAccess.ApiCalls;
using SureAppTest.Facade.Facades;
using SureAppTest.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SureAppTest
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Register Navigations
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<EventsListPage>();
            containerRegistry.RegisterForNavigation<MediSupplierPage>();
            containerRegistry.RegisterForNavigation<EventsFilterPage>();
            containerRegistry.RegisterForNavigation<EventMapPage>();

            //Register Types
            containerRegistry.Register<IRestService, RestService>();
            containerRegistry.Register<IEventsApi, EventsApi>();
            containerRegistry.Register<IEventsFacade, EventsFacade>();
            containerRegistry.Register<IMediCareService, MediCareService>();
        }
    }
}
