using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGZ.DataAccess
{
    public class SupportTicketingSystemDA
    {

        SupportTicketingSystemEntities objectDataContext;

        public SupportTicketingSystemDA()
        {
            objectDataContext = new SupportTicketingSystemEntities();
        }

        public bool ValidateUser(tbl_app_users user)
        {
            bool status = false;

            var getUser = (from usr in objectDataContext.tbl_app_users
                           where usr.Email == user.Email && usr.Password == user.Password
                           select usr).FirstOrDefault();

            if (getUser != null)
            {
                status = true;
            }

            return status;
        }

        public List<tbl_tickets> GetAllTickets()
        {
            return objectDataContext.tbl_tickets.Take(18).ToList();
        }

    }
}
