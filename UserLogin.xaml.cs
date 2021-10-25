using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Time_Manager
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            UserSignUp userSignUp = new UserSignUp();
            userSignUp.Show();
            this.Hide();
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
            tbUsername.Focus();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if((tbUsername.Text != null)&&(tbPassword != null))
            {
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                
                //then pass strings to checking method : checking() 

                /*then an if for outcome of checking 
                 * if true then send to main window 
                 * 
                 * if false then an error message is sent to available error lable
                 * --->N.B. error lable currently not available but will be in a later stage
                */


            }
        }

        public void Checking(string a, string b)
        {
            //here string a is compared to usernames in the db

            //if it is found then the password is compared to the one associated with the username from the db

            //if it is correct then this method will return true, if not then it will return false. 

            //-->N.B. this method is currently void but will be converted to later.
        }

    }
}
