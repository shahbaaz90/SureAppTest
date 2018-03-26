using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SureAppTest.ViewModels.ItemViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SureAppTest.ViewModels
{
	public class EventMapPageViewModel : ViewModelBase
	{
        EventItemViewModel eventDetails;

        public EventMapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Event Location";
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null && parameters.ContainsKey("EventDetails"))
            {
                eventDetails = (EventItemViewModel)parameters["EventDetails"];
            }
        }
    }
}
