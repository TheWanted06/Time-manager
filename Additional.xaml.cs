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
    /// Interaction logic for Additional.xaml
    /// </summary>
    public partial class Additional : Window
    {
        User user;
        public Additional(User user1)
        {
            InitializeComponent();
            user = user1;
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


                Dashboard dashboard = new Dashboard(user);
                dashboard.Show();

                this.Close();
                
            }
        }

    }
}
