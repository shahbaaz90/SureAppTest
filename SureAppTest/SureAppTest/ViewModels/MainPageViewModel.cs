using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SureAppTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Welcome";

            EventsListCommand = new DelegateCommand(async () => await NavigateToEventsList());
            MediSupplierCommand = new DelegateCommand(async () => await NavigateToMediSuppliers());
        }

        public ICommand EventsListCommand { get; private set; }
        public ICommand MediSupplierCommand { get; private set; }

        private async Task NavigateToEventsList()
        {
            NavigationParameters filterParams = new NavigationParameters
            {
                { Constants.IsFilteredKey, false },
                { Constants.StartDateKey, Convert.ToDateTime(Constants.DefStartDate) },
                { Constants.EndDateKey, Convert.ToDateTime(Constants.DefEndDate) },
                { Constants.CityKey, 0 }
            };

            await NavigationService.NavigateAsync("EventsListPage", filterParams);
        }

        private async Task NavigateToMediSuppliers()
        {
            await NavigationService.NavigateAsync("MediSupplierPage");
        }
    }
}
