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
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Media;
using Color = System.Drawing.Color;
using System.Windows.Forms;

namespace Time_Manager
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        User thisUser;
        public Dashboard(User user1 )
        {
            InitializeComponent();
            thisUser = user1;
            ListStartUpCheck();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddModule_Click(object sender, RoutedEventArgs e)
        {
            AddModules addModules = new AddModules(thisUser);
            addModules.Show();
            this.Hide();

        }
        public void ListStartUpCheck()
        {
            ClearList();
            int modulesNo = thisUser.moduleList.Count;
            if (modulesNo != 0)
            {
                foreach (var item in thisUser.Modules)
                {
                    moduleList.Items.Add(item.ModuleName);
                }
            }
        }
        public void ClearList()
        {
            moduleList.Items.Clear();
        }

        private void BtnRemoveModule_Click(object sender, RoutedEventArgs e)
        {

            //need the selected item
            string currentitem = moduleList.SelectedValue.ToString();

            //then pass selected item as a string to a message box asking the user to confirm
            string message = "Are you sure you want to delete" + currentitem+"module?";
            string caption = "Confirmation";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Question;
            if ((System.Windows.MessageBox.Show(message, caption, buttons, icon)) == MessageBoxResult.Yes)
            {
                //if yes then, the selected item's name is taken and the module with the same name is removed from the module list
                int position = moduleList.SelectedIndex;
                thisUser.Modules.RemoveAll((x) => x.ModuleName == currentitem);
                //then the a message box is shown to inform the user of this. The the list is reloaded 

                message = "The module has been removed";
                caption = "Confirmation";
                buttons = MessageBoxButton.OK;
                icon = MessageBoxImage.Information;
                System.Windows.MessageBox.Show(message, caption, buttons, icon);

            }
            else
            {
                  
            }
        }

        private void BtnSelet_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
