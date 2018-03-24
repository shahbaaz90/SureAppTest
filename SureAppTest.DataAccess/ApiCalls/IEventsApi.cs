using SureAppTest.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SureAppTest.DataAccess.ApiCalls
{
    public interface IEventsApi
    {
        Task<EventsListResponseModel> SearchEvents(EventsListRequestModel eventsListRequestModel);
    }
}
