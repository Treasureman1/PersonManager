using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Security
{
    public abstract class Securable
    {
        public string Name { get; set; }
        public abstract bool IsAuthorized(User user);
    }
}