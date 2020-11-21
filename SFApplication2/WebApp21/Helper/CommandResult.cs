using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp21.Facades;

namespace WebApp21.Helper
{
    public class CommandResult<TDto> : FacadeResult
    {
        /// <summary>
        /// The entity created
        /// Will be used to return dto as json in response body
        /// </summary>
        public TDto Entity { get; set; }

        /// <summary>
        /// Default constructor to allow for setting properties
        /// </summary>
        public CommandResult()
        { }

        /// <summary>
        /// Creates a result with a specific status and no content
        /// </summary>
        /// <param name="statusCode"></param>
        public CommandResult(FacadeStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
