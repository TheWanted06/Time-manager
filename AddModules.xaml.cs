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
        int Id;
        public AddModules(int Id)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
