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

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для BazaPolz.xaml
    /// </summary>
    public partial class BazaPolz : Page
    {
        public BazaPolz()
        {
            InitializeComponent();     
                 
        }
        



        private void Delete_Click(object sender, RoutedEventArgs e)
        {   
            
            var rec1 = DGridRecords.SelectedItems.Cast<Client>().ToList();            
          

            if (MessageBox.Show($"Вы точно хотите удалить следующие элементы ?", "Alarm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)                            
            {
                    AutoLandDB.GetContext().Client.RemoveRange(rec1);
                
                AutoLandDB.GetContext().SaveChanges();
                    DGridRecords.ItemsSource = AutoLandDB.GetContext().Client.ToList();                 

                    MessageBox.Show("Вы удалили");            
            }


        }

        private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutoLandDB.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                
                DGridRecords.ItemsSource = AutoLandDB.GetContext().Client.ToList();
            }
        }

        private void DGridRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutoLandDB.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}");
            }
        }
    }
}
