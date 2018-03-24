using SureAppTest.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.DataAccess.Config
{
    public static class ApiConfig
    {
        public static string SearchEvents()
        {
            return $"{SharedConfig.SaudiEventsApiRoot}/api/EventCalendar/SearchEvents";
        }
    }
}
