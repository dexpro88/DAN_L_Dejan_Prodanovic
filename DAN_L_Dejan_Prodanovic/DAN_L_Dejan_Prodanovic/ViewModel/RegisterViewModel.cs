using DAN_L_Dejan_Prodanovic.Command;
using DAN_L_Dejan_Prodanovic.Model;
using DAN_L_Dejan_Prodanovic.Service;
using DAN_L_Dejan_Prodanovic.Utility;
using DAN_L_Dejan_Prodanovic.Validation;
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
    class RegisterViewModel:ViewModelBase
    {
        Register view;
        IService service;

        public RegisterViewModel(Register registerView)
        {
            view = registerView;
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

            

            string encryptedString = (obj as PasswordBox).Password;

            string password = EncryptionHelper.Encrypt(encryptedString);

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(encryptedString))
            {
                MessageBox.Show("You must enter values for username and password");
                return;
            }
            tblUser newUser = new tblUser();
            newUser.UserName = UserName;
            newUser.UserPassword = password;

            tblUser userInDb = service.GetUserByUserName(UserName);
            if (userInDb!=null)
            {
                MessageBox.Show("Username is taken. Choose another username.");
                return;
            }

            if (!ValidationClass.IsPasswordValid(encryptedString))
            {
                MessageBox.Show("Password is not valid. \nMinimal length must be 6\n" +
                    "You need at least 2 upper case letters");
                return;
            }

            service.AddUser(newUser);
            MessageBox.Show("You succesfully created account");
            view.Close();
            


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

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
