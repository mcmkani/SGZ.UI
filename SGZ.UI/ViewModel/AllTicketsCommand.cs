using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGZ.UI.ViewModel
{
    public class AllTicketsCommand : ICommand
    {

        AllTicketsViewModel allTicketsViewModel;

        public AllTicketsCommand(AllTicketsViewModel TicketsViewModel)
        {
            allTicketsViewModel = TicketsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            bool action = false;
            if(allTicketsViewModel.Tickets.Count >= 0)
            {
                action = true;
            }

            return action;
        }

        public void Execute(object parameter)
        {
            allTicketsViewModel.ViewAllTickets();
        }
    }
}
