using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SureAppTest.Services
{
    public interface ILocalizeService
    {
        CultureInfo CurrentCulture { get; set; }
        CultureInfo CurrentUICulture { get; set; }
        CultureInfo GetCurrentCultureInfo();
        CultureInfo GetCurrentCultureInfo(string sLanguageCode);
        void SetLocale();
        void ChangeLocale(string sLanguageCode);
    }
}
