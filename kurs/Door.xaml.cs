using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для Door.xaml
    /// </summary>
    public partial class Door : Window
    {
        private Users _currentUser;
        public Door()
        {
            DataContext = _currentUser;
            InitializeComponent();

        }

        private void btnDoor_click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim() == "Admin" && PasswordTb.Text == "AdminKet11")
            {
                AdminPanel admin = new AdminPanel();
                admin.Show();
                Close();
            }
            
            else
            {
                
                bool successLogin = Logining(LoginTb.Text.Trim(), PasswordTb.Text.Trim());

                MessageBox.Show(successLogin ? "Вы вошли в систему" : "Вас не существует");
               
                if (successLogin == true)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    Close();
                }

            }
        }

        public static bool Logining(string email , string pass)
        {
            return final.GetContext().Users.Any(p => p.Login == email && p.Password == pass ) ;
        }

       /* public User Log(string email, string pass)
        {
            return EsoftEntities.GetContext().User.FirstOrDefault(p => p.Login == email && p.Password == pass);
        }*/


       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

       
    }
}
