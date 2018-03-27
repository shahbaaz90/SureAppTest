using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.Common;
using SureAppTest.Resources;
using SureAppTest.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SureAppTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ILocalizeService localizeService;

        public MainPageViewModel(INavigationService navigationService, ILocalizeService localizeService) 
            : base (navigationService)
        {
            this.localizeService = localizeService;
            Title = "Welcome";
            LangString = localizeService.CurrentCulture.TwoLetterISOLanguageName.ToUpper();

            EventsListCommand = new DelegateCommand(async () => await NavigateToEventsList());
            MediSupplierCommand = new DelegateCommand(async () => await NavigateToMediSuppliers());
            ChangeLocaleCommand = new DelegateCommand(ToggleLanguage);
        }

        private void ToggleLanguage()
        {
            if (LangString == "EN")
            {
                localizeService.ChangeLocale("ar");
                LangString = "AR";
            }
            else
            {
                localizeService.ChangeLocale("en");
                LangString = "EN";
            }
            
        }

        private string langString;
        public string LangString
        {
            get { return langString; }
            set { SetProperty(ref langString, value); }
        }

        public ICommand EventsListCommand { get; private set; }
        public ICommand MediSupplierCommand { get; private set; }
        public ICommand ChangeLocaleCommand { get; private set; }

        private async Task NavigateToEventsList()
        {
            NavigationParameters filterParams = new NavigationParameters
            {
                { Constants.IsFilteredKey, false },
                { Constants.StartDateKey, Convert.ToDateTime(Constants.DefStartDate, CultureInfo.InvariantCulture) },
                { Constants.EndDateKey, Convert.ToDateTime(Constants.DefEndDate, CultureInfo.InvariantCulture) },
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
