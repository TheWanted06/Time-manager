using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Additional.xaml
    /// </summary>
    public partial class Additional : Window
    {
        User user;

        public Additional(User user1)
        {
            InitializeComponent();
            this.user = user1;
        }

        //User theUser;
        
        private void tbFinish_Click(object sender, RoutedEventArgs e)
        {
            if((dpStartDate.SelectedDate != null) && (tbNoOfSemester.Text != null))
            {
                //checking the number of weeks input 

                int weeks =Convert.ToInt32(tbNoOfSemester.Text);
                DateTime date = (DateTime)dpStartDate.SelectedDate;

                user.semesterDate = date;
                user.week = weeks;

                string coneetionstring = "dfdf";
                SqlConnection con = new SqlConnection(coneetionstring);
                con.Open();
                string sqlQuery = $"Insert into [Users] (FirstName,LastName,Email,Username,Password,StartDate, Weeks) values( {user.name} ,{user.surname},{user.email},{user.username},{user.password},{user.semesterDate},{user.week})";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                //get the user Id
                sqlQuery = $"Select Id from [Users] where username={user.username} ";
                SqlCommand cm1 = new SqlCommand(sqlQuery,con);
                cm1.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cm1;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    int theId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
                    Dashboard dashboard = new Dashboard(theId);
                    dashboard.Show();
                    
                }
                con.Close();
                this.Close();
            }
        }

    }
}
