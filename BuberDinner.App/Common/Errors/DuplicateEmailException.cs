using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BuberDinner.App.Common.Errors
{

    public class DuplicateEmailException : System.Exception, IServiceException
    {

        public DuplicateEmailException(string message) : base(message) { }

        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public string ErrorMessage => "email already exists.";



    }
}
