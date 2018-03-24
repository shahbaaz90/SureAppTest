using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.Common.Helpers
{
    public class JsonSettings : JsonSerializerSettings
    {
        public JsonSettings()
        {
            NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
