using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Security
{
    public class RoleBasedSecurable : ISecurable
    {
        protected List<Role> _roles;

        public RoleBasedSecurable(string name, bool allowAnonymous, IEnumerable<Role> roles)
        {
            this.Name = name;

            this.AllowAnonymous = allowAnonymous;

            _roles = new List<Role>();

            _roles.AddRange(roles);
        }

        public IEnumerable<Role> Roles
        {
            get
            {
                foreach (var role in _roles)
                {
                    yield return role;
                }
            }
        }

        public bool AllowAnonymous { get; set; }

        public bool IsAuthorized(User user)
        {
            foreach (var role in Roles)
            {
                if (role.IsUserInRole(user))
                {
                    return (true);
                }
            }

            return (false);
        }

        public string Name { get; set; }
    }
}