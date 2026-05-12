using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public record LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
