using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGZ.AutoRefresh.UI.ViewModel.Command
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel ViewModel { get; set; }

        public LoginCommand(LoginViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.ValidateUser();
        }
    }
}
