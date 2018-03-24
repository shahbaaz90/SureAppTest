using System;
using System.Collections.Generic;
using System.Text;

namespace SureAppTest.DataAccess.Factories
{
    public enum ResponseContentStatus
    {
        OK,
        Fail
    }

    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public T Content { get; set; }

        /// <summary>
        /// Gets or sets the content status.
        /// </summary>
        /// <value>The content status.</value>
        public ResponseContentStatus ContentStatus { get; set; }

        /// <summary>
        /// Gets or sets the error response.
        /// </summary>
        /// <value>The error response.</value>
        public ErrorResult ErrorResponse { get; set; }
    }
}
