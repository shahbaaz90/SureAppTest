using SureAppTest.Common.Models;
using SureAppTest.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SureAppTest.Facade.Facades
{
    public interface IEventsFacade
    {
        Task<IEnumerable<EventModel>> SearchEvents(EventsListRequestModel eventsListRequestModel);

        Task<IEnumerable<EventModel>> FilterEvents(DateTime? startDate, DateTime? endDate, int cityID = 0);

        Task<IEnumerable<EventModel>> SearchEventByTitle(string eventTitle);
    }
}
