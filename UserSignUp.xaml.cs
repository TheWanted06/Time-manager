using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        string connectionstring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public UserSignUp()
        {
            InitializeComponent();
        }
        User user1;
        private void BtSignUp_Click(object sender, RoutedEventArgs e)
        {
            if(tbEmail.Text.Length==0)
            {
                errormessage.Text = "Enter an email.";
                tbEmail.Focus();
            }
            else if (!Regex.IsMatch(tbEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                tbEmail.Select(0, tbEmail.Text.Length);
                tbEmail.Focus();
            }
            else if(EmailChecked(tbEmail.Text)==false)
            {
                errormessage.Text = "Enter a unique Email address";
                tbEmail.Focus();
            }
            else if (tbUsername.Text.Length==0)
            {
                errormessage.Text = "Enter a Username";
                tbUsername.Focus();
            }
            else if(UsernameChecked(tbUsername.Text) == false)
            {
                errormessage.Text = "Enter a unique username";
                tbUsername.Focus();
            }
            else
            {
                string firstname = tbFirstName.Text;
                string lastname = tbSurname.Text;
                string email = tbEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter Confirm password.";
                    passwordBoxConfirm.Focus();
                }
                else if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[-+_!@#$%^&*.,?]).+$"))
                {
                    errormessage.Text = "Enter a password that has: One at least one lowercase,\n uppercase, special character and one numerical value";
                    passwordBox1.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    string address = tbEmail.Text;

                    user1 = new User();
                    user1.name = firstname;
                    user1.surname = lastname;
                    user1.email = address;
                    user1.username = tbUsername.Text;
                    user1.password = utils.hashPassword(passwordBox1.Password);

                    Additional additional = new Additional(user1);
                    additional.Show();
                    this.Hide();
                    Reset();
                }

            }    
        }

        private bool EmailChecked(string theEmail)
        {
            bool returned = false;

            string connectionstring = "dnd";
            con = new SqlConnection(connectionstring);
            con.Open();
            string sqlquery = "select * from [users] where Email=@email";
            cmd = new SqlCommand(sqlquery,con);
            cmd.Parameters.AddWithValue("@email", theEmail);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                returned = true;
            }

            return returned;
        }

        private bool UsernameChecked(string theUsername)
        {
            bool returned = false;

            //string connectionstring = "dnd";
            con = new SqlConnection(connectionstring);
            con.Open();
            string sqlquery = "select * from [users] where Username=@username";
            cmd = new SqlCommand(sqlquery, con);
            cmd.Parameters.AddWithValue("@username", theUsername);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                returned = true;
            }

            return returned;
        }

        private void BtCancel_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
            this.Hide();
        }
        public void Reset()
        {
            tbFirstName.Clear();
            tbSurname.Clear();
            tbEmail.Clear();
            tbUsername.Clear();
            passwordBox1.Clear();
            tbFirstName.Focus();
        }
    }
}
