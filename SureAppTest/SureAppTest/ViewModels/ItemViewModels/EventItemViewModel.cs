using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SureAppTest.ViewModels.ItemViewModels
{
	public class EventItemViewModel : BindableBase
	{
        private string eventTitle;
        public string EventTitle
        {
            get { return eventTitle; }
            set { SetProperty(ref eventTitle, value); }
        }

        private string eventCity;
        public string EventCity
        {
            get { return eventCity; }
            set { SetProperty(ref eventCity, value); }
        }

        private string eventImageURL;
       public string EventImageURL
        {
            get { return eventImageURL; }
            set { SetProperty(ref eventImageURL, value); }
        }

        private DateTime? eventStartDate;
        public DateTime? EventStartDate
        {
            get { return eventStartDate; }
            set { SetProperty(ref eventStartDate, value); }
        }

        private DateTime? eventEndDate;
        public DateTime? EventEndDate
        {
            get { return eventEndDate; }
            set { SetProperty(ref eventEndDate, value); }
        }
    }
}

