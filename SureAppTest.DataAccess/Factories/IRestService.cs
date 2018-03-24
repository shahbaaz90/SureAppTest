using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SureAppTest.DataAccess.Factories
{
    public interface IRestService
    {
        /// <summary>
        /// Makes the open request async.
        /// </summary>
        /// <returns>The open request async.</returns>
        /// <param name="requestUrl">Request URL.</param>
        /// <param name="verb">Verb param.</param>
        /// <param name="requestbody">Request body.</param>
        /// <param name="failSilent">If set to <c>true</c> fail silent.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<ApiResponse<T>> MakeOpenRequestAsync<T>(string requestUrl, HttpMethod verb, object requestbody, bool failSilent = false);
    }
}
