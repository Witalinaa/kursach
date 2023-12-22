using Microsoft.Win32;
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
using Microsoft.Win32;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
      private int id;
      private int idclients;
      private MainWindow main;
        private final dB = new final();
       
        public Profile (int iduser , int idclient, MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
            id = iduser;
            idclients = idclient; 

            LoginTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Login;
            NameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).UserName;
            SecondNameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Familia;
            LastNameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Otchestvo;
            
            
        }
        public Profile(int iduser, int idclient)
        {
            InitializeComponent();
            id = iduser;
            idclients = idclient;
            LoginTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Login;
            NameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).UserName;
            SecondNameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Familia;
            LastNameTb.Text = final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Otchestvo;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Login = LoginTb.Text;
            final.GetContext().Users.FirstOrDefault(p => p.UserID == id).UserName = NameTb.Text;
            final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Familia = SecondNameTb.Text;
            final.GetContext().Users.FirstOrDefault(p => p.UserID == id).Otchestvo = LastNameTb.Text;
            final.GetContext().SaveChanges();
            MessageBox.Show("Вы сохранены");
                        
        }

     

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
          
           
                var item = final.GetContext().Users.Where(p => p.UserID == id).FirstOrDefault();
                var item2 = final.GetContext().Smena.Where(p => p.UserID == idclients).FirstOrDefault();
                if (item2 != null)
                {
                    if (MessageBox.Show($"Вы точно хотите удалите данного пользователя {id}", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                    final.GetContext().Users.Remove(item);
                    final.GetContext().SaveChanges();
                        MessageBox.Show("Вы удалили себя досвидания");


                        Door door = new Door();
                        door.Show();
                    if (main != null)
                    {
                        main.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Фухх вы не удалились :)");
                }
                }
                else
                {
                    if (MessageBox.Show($"Вы точно хотите удалите данного пользователя {id}", "Alarm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                    final.GetContext().Users.Remove(item);
                    final.GetContext().Smena.Remove(item2);
                    final.GetContext().SaveChanges();
                        MessageBox.Show("Вы удалили себя досвидания");

                        Door door = new Door();
                        door.Show();
                    if (main != null)
                    {
                        main.Close();
                    }
                    }
                    else
                    {
                    MessageBox.Show("Фухх вы не удалились :)");
                    }
               
                }
               
               
        }

        private void btnBackDoor_click(object sender, RoutedEventArgs e)
        {
            Door door = new Door();
            door.Show();
            if (main != null)
            {
                main.Close();
            }
        }

    }
}
