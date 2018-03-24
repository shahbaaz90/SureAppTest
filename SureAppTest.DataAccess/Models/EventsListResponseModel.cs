using SureAppTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.DataAccess.Models
{
    public class EventsListResponseModel
    {
        public string Result { get; set; }

        public EventModel[] Records { get; set; }
    }
}
