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

        

        //private List<tblPizza> pizzaList;
        //public List<tblPizza> PizzaList
        //{
        //    get
        //    {
        //        return pizzaList;
        //    }
        //    set
        //    {
        //        pizzaList = value;
        //        OnPropertyChanged("PizzaList");
        //    }
        //}


        

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

        private void AddToOrderExecute()
        {
            try
            {
                //tblPizzaOrder thisPizza = FindPizzaByName(SelectedPizza.PizzaType);

                //if (thisPizza != null && currentAmount == 0)
                //{
                //    CurrentAmount = (int)thisPizza.Amount;
                //}
                //if (CurrentAmount <= 0 || CurrentAmount > 50)
                //{
                //    MessageBox.Show("You have to order between 1 and 50 pizzas of one type");
                //    return;
                //}
                //tblPizzaOrder newOrder = new tblPizzaOrder();
                //newOrder.PizzaID = SelectedPizza.ID;
                //newOrder.tblPizza = SelectedPizza;
                ////newOrder.tblPizza.Price = SelectedPizza.Price;

                //newOrder.Amount = CurrentAmount;
                ////MessageBox.Show(newOrder.tblPizza.PizzaType);
                ////SelectedPizza.Amount = currentAmount;

                ////PizzaClass newPizza = new PizzaClass(SelectedPizza.Name, SelectedPizza.Price) { Amount = currentAmount};

                //if (thisPizza != null)
                //{
                //    //MessageBox.Show(thisPizza.Amount.ToString());
                //    totalAmountNum -= ((int)thisPizza.Amount * (decimal)thisPizza.tblPizza.Price);
                //    OrederedPizzas.Remove(thisPizza);
                //}


                //totalAmountNum += (CurrentAmount * (int)SelectedPizza.Price);
                ////OrederedPizzas.Add(newPizza);
                //orederedPizzas.Add(newOrder);

                //TotalAmount = string.Format("Total order price {0}", totalAmountNum);
                //string outputStr = string.Format("Your order will contain {0} {1}", CurrentAmount, SelectedPizza.PizzaType);
                //CurrentAmount = 0;
                //MessageBox.Show(outputStr);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddToOrderExecute()
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
