using iCubed.AspNetCore.BasicAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet.Demo.API.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool SignIn(string username, string password)
        {
            return ( username.Equals("pippo") & password.Equals("admin") );
        }
    }
}
