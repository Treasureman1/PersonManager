using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Security
{
    public interface ISecurable
    {
        string Name { get; set; }
        bool AllowAnonymous{ get; }
        bool IsAuthorized(User user);
    }
}
