using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vrata24.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}