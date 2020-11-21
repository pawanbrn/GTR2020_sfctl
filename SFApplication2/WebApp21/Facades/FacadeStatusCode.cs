using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp21.Facades
{
    public enum FacadeStatusCode
    {
        Ok = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        MethodNotAllowed = 405
    }
}
