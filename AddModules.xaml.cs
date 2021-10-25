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
    /// Interaction logic for AddModules.xaml
    /// </summary>
    public partial class AddModules : Window
    {
        User SameUser;
        public AddModules( User thisUser)
        {
            InitializeComponent();
            SameUser = thisUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SameUser.
        }
    }
}
