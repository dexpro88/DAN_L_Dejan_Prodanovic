using DAN_L_Dejan_Prodanovic.Command;
using DAN_L_Dejan_Prodanovic.Model;
using DAN_L_Dejan_Prodanovic.Service;
using DAN_L_Dejan_Prodanovic.Validation;
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
    class AddSongViewModel:ViewModelBase
    {
        AddSong view;
        IService service;
        string UserName;

        public AddSongViewModel(AddSong addSongView)
        {
            view = addSongView;
            service = new ServiceClass();
            Song = new tblSong();
        }

        public AddSongViewModel(AddSong addSongView, string Username)
        {
            view = addSongView;
            service = new ServiceClass();

            this.UserName = Username;
            Song = new tblSong();
        }


        private tblSong song;
        public tblSong Song
        {

            get
            {
                return song;
            }
            set
            {
                song = value;
                OnPropertyChanged("Song");
            }
        }


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
                if (!ValidationClass.IsSongLengthValid(Song.SongLength))
                {
                    MessageBox.Show("Lenght is not in valid format");
                }

                tblUser user = service.GetUserByUserName(UserName);
                Song.UserID = user.UserID;

                service.AddSong(Song);

                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddSongExecute()
        {
            if (string.IsNullOrEmpty(Song.SongName)||string.IsNullOrEmpty(Song.Author)
                ||string.IsNullOrEmpty(Song.SongLength))
            {
                return false;
            }
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
