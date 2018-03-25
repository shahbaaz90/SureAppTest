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
using System.Windows.Input;

namespace SureAppTest.ViewModels
{
    public class EventsListPageViewModel : ViewModelBase
    {
        private readonly IEventsFacade eventsFacade;
        private bool isNearestEvent = true;
        private List<EventItemViewModel> allEvents;

        public EventsListPageViewModel(INavigationService navigationService,
            IEventsFacade eventsFacade) : base(navigationService)
        {
            this.eventsFacade = eventsFacade;

            Title = "Events Page";

            EventsList = new ObservableCollection<EventItemViewModel>();

            SortEventsCommand = new DelegateCommand(SortEvents)
                .ObservesCanExecute(() => CanSortAndFilter)
                .ObservesProperty(() => IsBusy);

            FilterEventsCommand = new DelegateCommand(FilterEvents)
                .ObservesCanExecute(() => CanSortAndFilter)
                .ObservesProperty(() => IsBusy);

            SearchTitleCommand = new DelegateCommand(SearchEventTitle)
                .ObservesCanExecute(() => CanSortAndFilter)
                .ObservesProperty(() => IsBusy);
        }

        private void SearchEventTitle()
        {

            IsBusy = true;

            //  var res = await eventsFacade.SearchEventByTitle(TextSearchTitle);
            //  PopulateEvents(res);

            var searchByTitle = new List<EventItemViewModel>(allEvents);

            searchByTitle = searchByTitle.Where(x => (x.EventTitle != null &&
            x.EventTitle.ToLower().Contains(TextSearchTitle.ToLower()))).ToList();

            EventsList.Clear();
            foreach (var item in searchByTitle)
            {
                EventsList.Add(item);
            }

            IsBusy = false;

        }

        private async void FilterEvents()
        {
            await NavigationService.NavigateAsync("EventsFilterPage");
        }

        public bool CanSortAndFilter
        {
            get { return !IsBusy; }
        }

        private void SortEvents()
        {
            var sortList = new List<EventItemViewModel>(EventsList);

            if (isNearestEvent)
            {
                sortList = sortList.OrderByDescending(x => x.EventStartDate).ToList();
            }
            else
            {
                sortList = sortList.OrderBy(x => x.EventStartDate).ToList();
            }
            isNearestEvent = !isNearestEvent;

            EventsList.Clear();
            foreach (var item in sortList)
            {
                EventsList.Add(item);
            }
        }

        private ObservableCollection<EventItemViewModel> eventsList;
        public ObservableCollection<EventItemViewModel> EventsList
        {
            get { return eventsList; }
            set { SetProperty(ref eventsList, value); }
        }

        private string textSearchTitle;
        public string TextSearchTitle
        {
            get { return textSearchTitle; }
            set { SetProperty(ref textSearchTitle, value); }
        }

        public ICommand SortEventsCommand { get; private set; }
        public ICommand FilterEventsCommand { get; private set; }
        public ICommand SearchTitleCommand { get; private set; }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null && parameters.ContainsKey(Constants.IsFilteredKey))
            {
                    if (parameters[Constants.IsFilteredKey] == null || 
                    parameters[Constants.StartDateKey] == null ||
                    parameters[Constants.EndDateKey] == null)
                    {
                        return;
                    }

                    IsBusy = true;

                var res = await eventsFacade.FilterEvents(Convert.ToDateTime(parameters[Constants.StartDateKey]),
                    Convert.ToDateTime(parameters[Constants.EndDateKey]));

                PopulateEvents(res);
                allEvents = new List<EventItemViewModel>(EventsList);

                IsBusy = false;
            }
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
                    EventCity = eventItem.CityEnName + ", " + eventItem.EventStartDate,
                    EventStartDate = eventItem.EventStartDate,
                    EventEndDate = eventItem.EventEndDate,
                    EventImageURL = SharedConfig.SaudiEventsApiRoot + eventItem.ImagePath
                });
            }
        }

    }
}
