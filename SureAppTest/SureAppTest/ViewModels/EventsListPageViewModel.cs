using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SureAppTest.ViewModels.ItemViewModels;
using SureAppTest.Common.Models;
using SureAppTest.Facade.Facades;
using SureAppTest.Common;

namespace SureAppTest.ViewModels
{
    public class EventsListPageViewModel : ViewModelBase
    {
        public EventsListPageViewModel(INavigationService navigationService,
            IEventsFacade eventsFacade) : base(navigationService)
        {
            this.eventsFacade = eventsFacade;

            Title = "Events Page";

            EventsList = new ObservableCollection<EventItemViewModel>();
        }

        private ObservableCollection<EventItemViewModel> eventsList;
        private readonly IEventsFacade eventsFacade;

        public ObservableCollection<EventItemViewModel> EventsList
        {
            get { return eventsList; }
            set { SetProperty(ref eventsList, value); }
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var res = await eventsFacade.FilterEvents(Convert.ToDateTime("Thu Jul 27 2017"),
                Convert.ToDateTime("Sun Dec 31 2017"));

            PopulateEvents(res);
        }

        private void PopulateEvents(IEnumerable<EventModel> events)
        {
            EventsList.Clear();

            if (events == null || !events.Any())
            {
                return;
            }

            foreach (var eventItem in events)
            {
                this.EventsList.Add(new EventItemViewModel()
                {
                     EventTitle = eventItem.EventTitle,
                     EventCity = eventItem.CityEnName,
                     EventStartDate = eventItem.EventStartDate,
                     EventEndDate = eventItem.EventEndDate,
                     EventImageURL = SharedConfig.SaudiEventsApiRoot + eventItem.ImagePath
                });
            }
        }

    }
}
