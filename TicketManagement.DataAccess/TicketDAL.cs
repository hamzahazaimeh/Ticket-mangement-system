using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TicketManagement.Entites;

namespace TicketManagement.DataAccess
{
    public class TicketDAL
    {
        public const string CONNECTION_STRING = "data source =LOCALHOST ; database=TICKET_MANAGEMENT ; integrated security=SSPI";
        public static void InertUser(TicketRequest request)
        {


            using (SqlConnection cn = new SqlConnection(CONNECTION_STRING))
            {

                using (SqlCommand cmd = new SqlCommand("ADDTICKET", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", request.Name);
                    cmd.Parameters.AddWithValue("@Description", request.Description);

                    cn.Open();
                    cmd.ExecuteNonQuery();


                }

            }




        }



        public static List<TicketRequest> GetTicketRequest()
        {
            List<TicketRequest> requests = new List<TicketRequest>();

            using (SqlConnection cn = new SqlConnection(CONNECTION_STRING))
            {
                string proc = "select * from ticketcomplaimenttable";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();


                    while (sdr.Read())
                    {

                        requests.Add(new TicketRequest
                        {

                            Name = sdr["Name"].ToString(),
                            Description = sdr["Description"].ToString(),


                        });

                    }

                    cn.Close();


                }
                return requests;

            }
        }




    }
}
