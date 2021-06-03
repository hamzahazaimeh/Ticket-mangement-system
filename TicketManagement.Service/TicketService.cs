using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.DataAccess;
using TicketManagement.Entites;
using TicketManagement.Service;

namespace TicketManagement.Service
{
    public class TicketService
    {
        public User GetUser(string username, string password)
        {
            User user = new User();
            user = UserDAL.GetUser(username, password);
            return user;
        }
      
    }

}
