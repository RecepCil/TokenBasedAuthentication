using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBasedAuthentication.WebAPI.Domain;

namespace TokenBasedAuthentication.WebAPI.Services
{
    public interface IUserLoginService
    {
        /// <summary>
        /// Check if user exists
        /// <summary>
        /// <param name="userLogin">IsUser</param>
        bool IsUser(UserLogin userLogin);

        /// <summary>
        /// Insert new account
        /// </summary>
        /// <param name="userLogin"></param>
        void InsertUser(UserLogin userLogin);

        /// <summary>
        /// Log In
        /// </summary>
        /// <param name="userLogin"></param>
       Task LogInAsync(UserLogin userLogin);
    }
}
