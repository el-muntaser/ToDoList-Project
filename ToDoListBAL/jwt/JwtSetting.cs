using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBAL.jwt
{
    public class JwtSetting
    {   
            public string? Issuer { get; set; }
            public string? Audience { get; set; }
            public string? SigningKey { get; set; }
            public DateTime Exdate { get; set; }

    }
}
