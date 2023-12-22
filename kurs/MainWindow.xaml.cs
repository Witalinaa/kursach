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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int idclient;
        private int id;
        public MainWindow()
        {
            InitializeComponent();
            Manager.MainFrame = MainFrame;
            MainFrame.Navigate(new Home());
        }
        public MainWindow(int iduser)
        {
         
            id = iduser;



        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
   

        private void RadioButtonNews_Checked(object sender, RoutedEventArgs e)
        {
          
            MainFrame.Navigate(new Home());
        }

        


        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TurnApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DragApp_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }




        private void RadioButtonAction_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new zakaz());
        }

        private void Myprofile(object sender, RoutedEventArgs e)
        {
           MainFrame.Navigate(new Profile(id, idclient, this));
        }          

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BazaPolz());
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
               
        
    }
}
