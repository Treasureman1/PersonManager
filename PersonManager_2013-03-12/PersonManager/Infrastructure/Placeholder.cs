using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure.Security;
using System.Security.Principal;

namespace Infrastructure
{
    public class Placeholder
    {
        /// <summary>
        /// This is simply a stub; it should be replaced with a method that reads the appropriate user
        /// from the database
        /// </summary>
        /// <returns></returns>
        public static User GetUser( string userName )
        {
            IIdentity identity = new SystemIdentity( userName );

            string[] roleNames = new string[] { };

            switch (userName)
            {
                case "rrobert":
                    roleNames = new string[] { "Role1" };
                    break;
                default:
                    roleNames = new string[] { "Role2" };
                    break;
            }

            List<Role> roles = new List<Role>();
            foreach (var roleName in roleNames)
            {
                roles.Add( new Role( roleName ) );
            }

            User toReturn = new User(identity, roles);

            return (toReturn);
        }

        public static ISecurable GetSecurable(string securableName)
        {
            string[] roleNames = new string[]{};
            bool allowAnonymous;

            switch (securableName.ToLower())
            {
                case "account.login":
                    allowAnonymous = true;
                    break;
                case "default":
                    allowAnonymous = false;
                    roleNames = new string[] { "Role1" };
                    break;
                default:
                    allowAnonymous = false;
                    break;
            }

            List<Role> roles = new List<Role>();

            foreach (var roleName in roleNames)
            {
                roles.Add(new Role( roleName ));
            }

            var toReturn = new RoleBasedSecurable( securableName, allowAnonymous, roles);

            return (toReturn);
        }
    }
}