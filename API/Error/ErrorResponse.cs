using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ErrorResponse : ApiResponse
    {
        public ErrorResponse() : base(400)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
