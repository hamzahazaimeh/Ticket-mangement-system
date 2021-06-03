using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TicketManagement.Entites;
using TicketManagement.Service;




namespace TicketManagment.API.Controllers
{
    public class UserController : ApiController
    {


        // GET: api/user/login?username={username}&password={password}
        [System.Web.Http.HttpPost]
        public bool Login(User user)
        
        {
            bool islogin = false;
            TicketService ticketService = new TicketService();
            User userObj = ticketService.GetUser(user.UserName, user.UserPassword);
            if (userObj.ID != 0)
                islogin = true;
            else
                islogin = false;

            return islogin;
        }
         
        
      
    }
}
