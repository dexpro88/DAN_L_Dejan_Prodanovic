using DAN_L_Dejan_Prodanovic.Command;
using DAN_L_Dejan_Prodanovic.Model;
using DAN_L_Dejan_Prodanovic.Service;
using DAN_L_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        tblUser userLogedIn;


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
            userLogedIn = service.GetUserByUserName(Username);
            SongList = service.GetSongsOfUser(userLogedIn.UserID);
        }




        private tblSong selectedSong;
        public tblSong SelectedSong
        {
            get
            {
                return selectedSong;
            }
            set
            {
                selectedSong = value;
                OnPropertyChanged("SelectedSong");
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
                AddSong addSong = new AddSong(Username);
                addSong.ShowDialog();
                SongList = service.GetSongsOfUser(userLogedIn.UserID);
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

        private ICommand deleteSong;
        public ICommand DeleteSong
        {
            get
            {
                if (deleteSong == null)
                {
                    deleteSong = new RelayCommand(param => DeleteSongExecute(), param => CanDeleteSongExecute());
                }
                return deleteSong;
            }
        }

        private void DeleteSongExecute()
        {
            try
            {
                if (SelectedSong != null)
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure that you want to delete this song?" +
                         "" , "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    int songId = SelectedSong.SongID;

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            service.DeleteSong(songId);
                            SongList = service.GetSongsOfUser(userLogedIn.UserID);

                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteSongExecute() { 
            if (SelectedSong == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private ICommand playSong;
        public ICommand PlaySong
        {
            get
            {
                if (playSong == null)
                {
                    playSong = new RelayCommand(param => PlaySongExecute(), param => CanPlaySongExecute());
                
                }
                return playSong;
            }
        }

        private void PlaySongExecute()
        {
            try
            {
                if (SelectedSong != null)
                {
                    Thread t = new Thread(writeToFile);
                    t.Start();
                    MessageBox.Show("Song is playing");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanPlaySongExecute()
        {
            if (SelectedSong == null)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        private void writeToFile()
        {
            string fileName = string.Format(@"..\..\MyMusic" + userLogedIn.UserName+".txt");
            using (StreamWriter sw = new StreamWriter(fileName))
            {

                string str = string.Format(SelectedSong.SongName+" " + SelectedSong.Author
                    +" " + SelectedSong.SongLength);
                    sw.WriteLine(str);
                 
            }
        }
    }
}
