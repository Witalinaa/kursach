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
        private AutoLandDB dB = new AutoLandDB();
       
        public Profile(int iduser , int idclient, MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
            id = iduser;
            idclients = idclient; 
            LoginTb.Text = AutoLandDB.GetContext().User.FirstOrDefault(p => p.Id_user == id).Login;
            NameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Name;
            SecondNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).SecondName;
            LastNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).LastName;
            PhoneTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Phone;
            LoadImage.ImageSource = new BitmapImage(new Uri(AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).ImagePath)); 
            NickNameTb.Text = AutoLandDB.GetContext().User.FirstOrDefault(p => p.Id_user == id).Login;

            
        }
        public Profile(int iduser, int idclient)
        {
            InitializeComponent();
            id = iduser;
            idclients = idclient;
            LoginTb.Text = AutoLandDB.GetContext().User.FirstOrDefault(p => p.Id_user == id).Login;
            NameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Name;
            SecondNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).SecondName;
            LastNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).LastName;
            PhoneTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Phone;
            LoadImage.ImageSource = new BitmapImage(new Uri(AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).ImagePath));
            NickNameTb.Text = AutoLandDB.GetContext().User.FirstOrDefault(p => p.Id_user == id).Login;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            AutoLandDB.GetContext().User.FirstOrDefault(p => p.Id_user == id).Login = LoginTb.Text;
            AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Name = NameTb.Text;
            AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).SecondName = SecondNameTb.Text;
            AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).LastName = LastNameTb.Text;
            AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Phone = PhoneTb.Text;
            AutoLandDB.GetContext().SaveChanges();
            MessageBox.Show("Вы сохранены");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            ofdPicture.FilterIndex = 100;

            if (ofdPicture.ShowDialog() == true)
            {
                LoadImage.ImageSource = new BitmapImage(new Uri(ofdPicture.FileName));
                AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).ImagePath = "pack://application:,,,/Images/"+ofdPicture.SafeFileName;
                AutoLandDB.GetContext().SaveChanges();
            }
        }

     

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
          
           
                var item = AutoLandDB.GetContext().User.Where(p => p.Id_user == id).FirstOrDefault();
                var item1 = AutoLandDB.GetContext().Client.Where(p => p.Id_user == id).FirstOrDefault();
                var item2 = AutoLandDB.GetContext().Record.Where(p => p.Id_client == idclients).FirstOrDefault();
                if (item2 != null)
                {
                    if (MessageBox.Show($"Вы точно хотите удалите данного пользователя {id}", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                    AutoLandDB.GetContext().User.Remove(item);
                    AutoLandDB.GetContext().Client.Remove(item1);
                    AutoLandDB.GetContext().Record.Remove(item2);
                    AutoLandDB.GetContext().SaveChanges();
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
                    AutoLandDB.GetContext().User.Remove(item);
                    AutoLandDB.GetContext().Client.Remove(item1);
                    AutoLandDB.GetContext().SaveChanges();
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
