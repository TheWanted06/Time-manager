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
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        //SqlConnection con = new SqlConnection();
        string sqlquery;
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
            passwordBox.Clear();
            tbUsername.Focus();
        }

        private void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if((tbUsername.Text == null)||(tbUsername.Text.Length== 0))
            {
                errormessage.Text = "Please enter a Username";
                tbUsername.Focus();
            }
            else
            {
                string username = tbUsername.Text;
                string password = passwordBox.Password;

                if (password.Length == 0)
                {
                    errormessage.Text = "Enter password.";
                    passwordBox.Focus();
                }
                else if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[-+_!@#$%^&*.,?]).+$"))
                {
                    errormessage.Text = "Enter a password that has: One at least one lowercase,\n uppercase, special character and one numerical value";
                    passwordBox.Focus();
                }
                else
                {
                    //hashed password
                    string hashedpassword = utils.hashPassword(password);

                    //DBconnection objconn = new DBconnection();
                    //objconn.connection(); //calling connection   
                    //string sqlquery = "";
                    //SqlCommand com = new SqlCommand(sqlquery, objconn.con);
                    //com.CommandType = CommandType.StoredProcedure;
                    //com.Parameters.AddWithValue("@UserId", username);
                    //com.Parameters.AddWithValue("@", password);

                    //get the User Id then pass it to DashBoard();
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();

                    sqlquery = $"Select ID from [User] where username = {username} and password = {hashedpassword} ";
                    SqlCommand cmd = new SqlCommand(sqlquery, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;

                    int IsValidUser = Convert.ToInt32(cmd.ExecuteScalar());
                    if (IsValidUser == 1) //if user found it returns 1  
                    {
                        
                        cmd.CommandType = CommandType.Text;
                        adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        if(dataset.Tables[0].Rows.Count > 0)
                        {
                            int theId = Convert.ToInt32(dataset.Tables[0].Rows[0]["Id"]);
                            Dashboard dashOBJ = new Dashboard(theId);
                            dashOBJ.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        errormessage.Text="InValid UserId Or word";
                        tbUsername.Focus();
                    }
                }
            }
        }

    }
}
