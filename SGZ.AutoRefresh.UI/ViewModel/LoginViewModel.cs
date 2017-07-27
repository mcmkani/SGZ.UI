using SGZ.AutoRefresh.UI.ViewModel.Command;
using SGZ.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGZ.AutoRefresh.UI.ViewModel
{
    public class LoginViewModel
    {

        public LoginCommand loginCommand { get; set; }
        public string  UserName { get; set; }
        public string  Password { get; set; }

        private SupportTicketingSystemDA dataAccessRepository;

        public LoginViewModel()
        {
            this.UserName = "chinu.manjaiah@saggezza.com";
            this.Password = "Saggezza@123";
            loginCommand = new LoginCommand(this);
            dataAccessRepository = new SupportTicketingSystemDA();
        }

        public void ValidateUser()
        {
            bool isUserValid = false;

            if( !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(Password) )
            {
                tbl_app_users loggedinUser = new tbl_app_users();
                loggedinUser.Email = this.UserName;
                loggedinUser.Password = this.Password;
                isUserValid = dataAccessRepository.ValidateUser(loggedinUser);
            }

            if(isUserValid)
            {
                MainWindow HomePage = new MainWindow();
                HomePage.Show();

                for (int intCounter = 0; intCounter <= App.Current.Windows.Count - 1; intCounter++)
                {
                    if (App.Current.Windows[intCounter].Name == "loginWindow")
                    {
                        //App.Current.Windows[intCounter].Hide();
                        App.Current.Windows[intCounter].Close();
                        break;
                    }
                }

            }

        }

    }
}
