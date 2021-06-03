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
    public class TicketCompaimentService
    {
        public void InertUser(TicketRequest request )
        {
            TicketDAL.InertUser(request);
            
        }

        public List<TicketRequest> GetTicketRequests()
        {
            return TicketDAL.GetTicketRequest();
        }
    }
}
