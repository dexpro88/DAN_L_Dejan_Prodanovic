using DAN_L_Dejan_Prodanovic.Command;
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
    class AddSongViewModel:ViewModelBase
    {
        AddSong view;
        IService service;

        public AddSongViewModel(AddSong addSongView)
        {
            view = addSongView;
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
                //OrderView orderView = new OrderView(orederedPizzas, totalAmountNum, JMBG);
                //orderView.ShowDialog();

                //if ((orderView.DataContext as OrderViewModel).OrderConfirmed == true)
                //{
                //    ViewMakeOrder = Visibility.Hidden;
                //    ViewShowOrder = Visibility.Visible;
                //    orderConfirmed = true;
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddSongExecute()
        {
            //if (!orederedPizzas.Any() || orderConfirmed)
            //{
            //    return false;
            //}
            //if (ordersOfUser.Any())
            //{
            //    if (ordersOfUser.Last().OrderStatus == "W")
            //    {
            //        return false;
            //    }
            //}
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
