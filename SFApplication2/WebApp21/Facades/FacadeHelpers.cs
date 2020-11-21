using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp21.Helper;

namespace WebApp21.Facades
{
    public class FacadeHelpers<TDto>
    {
        /// <summary>
        /// Helper methods for returning Command Results to make the facade calls easier to read
        /// by removing the long generic type names 
        /// </summary>
        public static class Command
        {
           
            public static CommandResult<TDto> Created(TDto dto)
            {
                return new CommandResult<TDto>
                {
                    StatusCode = FacadeStatusCode.Created,
                    Entity = dto
                };
            }

            public static CommandResult<TDto> NoContent()
            {
                return new CommandResult<TDto>
                {
                    StatusCode = FacadeStatusCode.NoContent
                };
            }
        }
    }
}
