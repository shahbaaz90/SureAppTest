using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.Common;
using SureAppTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            PickerCity = new ObservableCollection<PickerItem>()
            {
                new PickerItem{Value = 0, DisplayField = "Select City"},
                new PickerItem{Value = 1, DisplayField = "Al Riyadh"},
                new PickerItem{Value = 2, DisplayField="Al Dereia"},
                new PickerItem{Value = 3, DisplayField="Al Kharj"}
            };
            SelectedCity = PickerCity[0];
        }

        private async void FilterEvents()
        {
            NavigationParameters filterParams = new NavigationParameters
            {
                { Constants.IsFilteredKey, true },
                { Constants.StartDateKey, EventStartDate },
                { Constants.EndDateKey, EventEndDate },
                { Constants.CityKey, SelectedCity.Value }
            };

            await NavigationService.GoBackAsync(filterParams);
        }

        private ObservableCollection<PickerItem> pickerCity;
        public ObservableCollection<PickerItem> PickerCity
        {
            get { return pickerCity; }
            set { SetProperty(ref pickerCity, value); }
        }

        private PickerItem selectedCity;
        public PickerItem SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value); }
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
    }

}
