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
using System.Windows.Input;

namespace DAN_L_Dejan_Prodanovic.ViewModel
{
    class MainMenuViewModel:ViewModelBase
    {
        MainMenu menuView;
        
        private string Username;
        IService service;

        
        public MainMenuViewModel(MainMenu menuViewOpen)
        {
            menuView = menuViewOpen;
            service = new ServiceClass();
            
        }

        public MainMenuViewModel(MainMenu menuViewOpen, string Username)
        {
            menuView = menuViewOpen;
            service = new ServiceClass();
             
            this.Username = Username;
        }
        

        

        private string totalAmount = "Total order amount: 0";
        public string TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        private int currentAmount = 0;
        public int CurrentAmount
        {
            get
            {
                return currentAmount;
            }
            set
            {
                currentAmount = value;
                OnPropertyChanged("CurrentAmount");

            }
        }



        private List<tblSong> songList;
        public List<tblSong> SongList
        {
            get
            {
                return songList;
            }
            set
            {
                songList = value;
                OnPropertyChanged("SongList");
            }
        }




        #region Commands

        private ICommand addSong;
        public ICommand AddSong
        {
            get
            {
                if (addSong == null)
                {
                    addSong = new RelayCommand(param => AddSongExecute(), param => CanAddSongExecute());
                }
                return addSong;
            }
        }

        private void AddSongExecute()
        {
            try
            {
                AddSong addSong = new AddSong();
                addSong.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddSongExecute()
        {
            
            return true;
        }

       

       

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }

        private void LogoutExecute()
        {
            try
            {
                LoginView loginView = new LoginView();
                loginView.Show();
                menuView.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
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

                menuView.Close();

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
        #endregion

        
    }
}
