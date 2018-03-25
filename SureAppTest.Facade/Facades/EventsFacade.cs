using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SureAppTest.Common;
using SureAppTest.Common.Models;
using SureAppTest.DataAccess.ApiCalls;
using SureAppTest.DataAccess.Models;

namespace SureAppTest.Facade.Facades
{
    public class EventsFacade : IEventsFacade
    {
        private readonly IEventsApi eventsApi;

        public EventsFacade(IEventsApi eventsApi)
        {
            this.eventsApi = eventsApi;
        }

        public async Task<IEnumerable<EventModel>> SearchEventByTitle(string eventTitle)
        {
            EventsListRequestModel eventsListQuery = new EventsListRequestModel()
            {
                eventTitle = eventTitle,
                fromDate = Constants.DefStartDate,
                toDate = Constants.DefEndDate,
                cityID = 0
            };

            var res = await this.SearchEvents(eventsListQuery);

            return res;
        }

        public async Task<IEnumerable<EventModel>> FilterEvents(DateTime? startDate, DateTime? endDate, int cityID = 0)
        {
            EventsListRequestModel eventsListQuery = new EventsListRequestModel() {
                fromDate = startDate?.ToString(Constants.DefDateFormat),
                toDate = endDate?.ToString(Constants.DefDateFormat),
                cityID = cityID
            };

            var res = await this.SearchEvents(eventsListQuery);

            return res;
        }

        public async Task<IEnumerable<EventModel>> SearchEvents(EventsListRequestModel eventsListRequestModel)
        {
            eventsListRequestModel.categoryID = "0";
            eventsListRequestModel.eventId = string.Empty;
            eventsListRequestModel.lang = "en";
            eventsListRequestModel.pageSize = 25;
            eventsListRequestModel.regionID = 0;
            eventsListRequestModel.startIndex = 0;

            var res = await eventsApi.SearchEvents(eventsListRequestModel);

            return res?.Records;
        }
    }
}
