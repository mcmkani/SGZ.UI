using SGZ.DataAccess;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGZ.AutoRefresh.UI  
{
    public class TicketDetails : NotificationObject
    {

        private ObservableCollection<tbl_tickets> _ticketDetails = new ObservableCollection<tbl_tickets>();

        public SupportTicketingSystemDA dataAccessRepository = new SupportTicketingSystemDA();

        public ObservableCollection<tbl_tickets> TicketInfo
        {
            get
            {
                return _ticketDetails;
            }

            set
            {
                _ticketDetails = value;
                RaisePropertyChanged("TicketInfo");
            }
        }

        public TicketDetails()
        {
            GetTicketDetails();
        }

        public void GetTicketDetails()
        {
            var items = dataAccessRepository.GetAllTickets();

            foreach (var eachItem in items)
            {
                _ticketDetails.Add(eachItem);
            }
        }


    }
}
