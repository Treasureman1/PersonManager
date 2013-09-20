using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Security
{
    public class Role
    {
        protected HashSet<string> _users;

        public Role( string name )
        {
            this.Name = name;
            _users = new HashSet<string>();
        }

        public string Name { get; set; }

        public void AddUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                // assumption: user.Identity.Name is unique across users.
                _users.Add(user.Identity.Name);
            }
        }

        public bool IsUserInRole(User user)
        {
            return (_users.Contains(user.Identity.Name));
        }

    }
}