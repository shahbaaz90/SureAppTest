using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using SureAppTest.DataAccess.Config;
using SureAppTest.DataAccess.Factories;
using SureAppTest.DataAccess.Models;

namespace SureAppTest.DataAccess.ApiCalls
{
    public class EventsApi : IEventsApi
    {
        private readonly IRestService restService;

        public EventsApi(IRestService restService)
        {
            this.restService = restService;
        }

        public async Task<EventsListResponseModel> SearchEvents(EventsListRequestModel eventsListRequestModel)
        {
            try
            {
                string requestUrl = ApiConfig.SearchEvents();

                var result = await this.restService.MakeOpenRequestAsync<EventsListResponseModel>(
                    requestUrl,
                    HttpMethod.Post,
                    eventsListRequestModel);

                return result.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} GetUserSessionId Exception: {1}", GetType().Name, ex.Message);
                throw ex;
            }
        }
    }
}
