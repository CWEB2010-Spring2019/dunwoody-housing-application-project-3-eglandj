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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Three_GUI
{
    /// <summary>
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : Page
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void Exit_App_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<Window>().FirstOrDefault();
            window.Close();
        }

        private void New_Resident_Click(object sender, RoutedEventArgs e)
        {
            new_Resident newResidentPage = new new_Resident();
            this.NavigationService.Navigate(newResidentPage);
        }

        private void Resident_Search_Click(object sender, RoutedEventArgs e)
        {
            ResidentSearch residentSearchPage = new ResidentSearch();
            this.NavigationService.Navigate(residentSearchPage);
        }
    }
}
