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
    public class TicketComplaimentController : ApiController
    {


        // GET: api/TicketComplaiment/GetAllTickets
        [System.Web.Http.HttpGet]
        public List<TicketRequest> GetAllTickets()
        {
            TicketCompaimentService Service = new TicketCompaimentService();
            List<TicketRequest> requests = Service.GetTicketRequests();
            return requests;

        }
        // POST api/TicketComplaiment/AddTicket
        [System.Web.Http.HttpPost]
        public void AddTicket([FromBody]TicketRequest request)
        {

            TicketCompaimentService service = new TicketCompaimentService();
            
            service.InertUser(request);         
        }



    }
}