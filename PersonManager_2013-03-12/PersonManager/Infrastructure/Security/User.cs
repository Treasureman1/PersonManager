using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace Infrastructure.Security
{
    public class User : IPrincipal
    {
        public IIdentity Identity { get; set; }
        protected ISet<string> _roleNames;

        public User(IIdentity identity, IEnumerable<Role> roles)
        {
            this.Identity = identity;

            // Passing a custom comparer to force _roleNames to be case INsensitive
            _roleNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var role in roles)
            {
                _roleNames.Add(role.Name);
            }
        }

        public bool IsInRole(string role)
        {
            return (_roleNames.Contains(role));
        }

    }
}