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
    /// Interaction logic for UserSignUp.xaml
    /// </summary>
    public partial class UserSignUp : Window
    {
        public UserSignUp()
        {
            InitializeComponent();
        }
        User user1;
        private void BtSignUp_Click(object sender, RoutedEventArgs e)
        {
            if ((tbName.Text != null) && (tbSurname != null)&&(tbEmail.Text != null)&&(tbUsername.Text != null) && (tbPassword.Text != null))
            {
                user1 = new User();
                user1.name = tbName.Text;
                user1.surname = tbSurname.Text;
                user1.email = tbEmail.Text;
                user1.username = tbUsername.Text;
                user1.password = tbPassword.Text;


                Additional additional = new Additional(user1);
                additional.Show();
                this.Hide();
                
                
            }
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }
        public void Clear()
        {
            tbName.Clear();
            tbSurname.Clear();
            tbEmail.Clear();
            tbUsername.Clear();
            tbPassword.Clear();
            tbName.Focus();
        }
    }
}
