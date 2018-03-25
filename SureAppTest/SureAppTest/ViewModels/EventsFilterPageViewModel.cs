using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SureAppTest.ViewModels
{
	public class EventsFilterPageViewModel : ViewModelBase
	{
        public EventsFilterPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Filters";

            FilterEventsCommand = new DelegateCommand(FilterEvents);
        }

        private async void FilterEvents()
        {
            NavigationParameters filterParams = new NavigationParameters
            {
                { Constants.IsFilteredKey, true },
                { Constants.StartDateKey, EventStartDate },
                { Constants.EndDateKey, EventEndDate },
                { Constants.CityKey, 0 }
            };

            await NavigationService.GoBackAsync(filterParams);
        }

        public ICommand FilterEventsCommand { get; private set; }

        private DateTime eventStartDate = Convert.ToDateTime(Constants.DefStartDate);
        public DateTime EventStartDate
        {
            get { return eventStartDate; }
            set { SetProperty(ref eventStartDate, value); }
        }

        private DateTime eventEndDate = Convert.ToDateTime(Constants.DefEndDate);
        public DateTime EventEndDate
        {
            get { return eventEndDate; }
            set { SetProperty(ref eventEndDate, value); }
        }

        private string selectedCity;
        public string SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value); }
        }


    }
}
