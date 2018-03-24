using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SureAppTest.ViewModels.ItemViewModels;

namespace SureAppTest.ViewModels
{
    public class EventsListPageViewModel : ViewModelBase
    {
        public EventsListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Events Page";
        }

        private ObservableCollection<EventItemViewModel> eventsList;
        public ObservableCollection<EventItemViewModel> EventsList
        {
            get { return eventsList; }
            set { SetProperty(ref eventsList, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            EventsList = new ObservableCollection<EventItemViewModel>() {
                new EventItemViewModel()
            { EventCity = "Karachi", EventTitle ="BigBash" },
                new EventItemViewModel()
            { EventCity = "Karachi", EventTitle ="BigBash" },
                new EventItemViewModel()
            { EventCity = "Karachi", EventTitle ="BigBash" },
            };
        }

    }
}
