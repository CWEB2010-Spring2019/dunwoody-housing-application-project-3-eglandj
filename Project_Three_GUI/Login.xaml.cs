﻿using System;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        object parent;
        public Login(object _parent)
        {
            parent = _parent;
            InitializeComponent();
            Warning_Label.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(Username.Text == "home" && Password.Password == "1234")
            {
                Selection selectionPage = new Selection(parent);
                ((MainWindow)parent).Content = selectionPage.Content;
                //this.NavigationService.Navigate(selectionPage);
            }
            else
            {
                Warning_Label.Visibility = Visibility.Visible;
            }
        }
    }
}
