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
    public static class UserDAL
    {
        public const string CONNECTION_STRING = "data source =LOCALHOST ; database=TICKET_MANAGEMENT ; integrated security=SSPI";

        public static User GetUser(string username, string password)
        {
            User user = new User();
            using (SqlConnection cn = new SqlConnection(CONNECTION_STRING))
            {
                string proc = "select * from UserTable WHERE USER_NAME = '" + username + "'And USER_PASSWORD ='" + password + "';";
                using (SqlCommand cmd = new SqlCommand(proc, cn))
                
                
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(
                        CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        user = GetUser(rdr);
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
            }
            return user;

        }
        public static User GetUser(SqlDataReader rdr)
        {
            User user = new User();
            user.ID = Convert.ToInt32(rdr["ID"]);
            user.UserName = rdr["USER_NAME"].ToString();
            user.UserPassword = rdr["USER_PASSWORD"].ToString();

            return user;
        }
    }
}
