using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

            EventsListCommand = new DelegateCommand(NavigateToEventsList);
            MediSupplierCommand = new DelegateCommand(NavigateToMediSuppliers);
        }

        public ICommand EventsListCommand { get; private set; }
        public ICommand MediSupplierCommand { get; private set; }

        private async void NavigateToEventsList()
        {
            await NavigationService.NavigateAsync("EventsListPage");
        }

        private async void NavigateToMediSuppliers()
        {
            await NavigationService.NavigateAsync("MediSupplierPage");
        }
    }
}
