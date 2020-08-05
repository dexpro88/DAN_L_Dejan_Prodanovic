using DAN_L_Dejan_Prodanovic.Command;
using DAN_L_Dejan_Prodanovic.Model;
using DAN_L_Dejan_Prodanovic.Service;
using DAN_L_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_L_Dejan_Prodanovic.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;
        IService service;
        public LoginViewModel(LoginView loginView)
        {
            view = loginView;
            service = new ServiceClass();
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string password = (obj as PasswordBox).Password;

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }

            tblUser userInDb = service.GetUserByUserNameAndPassword(UserName,password);
            if (userInDb==null)
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }
            else
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                view.Close();
            }


        }

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand(RegisterExecute);
                    return register;
                }
                return register;
            }
        }

        void RegisterExecute(object obj)
        {

            Register register = new Register();
            register.ShowDialog();


        }
    }
}
