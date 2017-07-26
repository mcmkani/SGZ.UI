using SGZ.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGZ.UI.ViewModel
{
    public class AllTicketsViewModel
    {

        public ObservableCollection<tbl_tickets> Tickets { get; set; }

        public SupportTicketingSystemDA objectDataAccess;

        public ICommand AllTickets
        {
            get
            {
                return new AllTicketsCommand(this);
            }
        }

        public AllTicketsViewModel()
        {
            Tickets = new ObservableCollection<tbl_tickets>();
            objectDataAccess = new SupportTicketingSystemDA();
        }

        public void ViewAllTickets()
        {
            List<tbl_tickets> lstTickets = objectDataAccess.GetAllTickets();

            foreach(var ticket in lstTickets)
            {
                Tickets.Add(ticket);
            }

        }



    }
}
