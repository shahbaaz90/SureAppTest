using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.DataAccess.Factories
{
    public class ErrorResult
    {
        /// <summary>
        ///     Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        ///     Gets or sets the status description.
        /// </summary>
        public string StatusDescription { get; set; }
    }
}
