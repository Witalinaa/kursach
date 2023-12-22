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
    public partial class zakaz : Page
    {
        public zakaz()
        {
            InitializeComponent();
        }

       

        private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                final.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                DGridRecords.ItemsSource = final.GetContext().Users.ToList();
            }
        }

        private void DGridRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                final.GetContext().SaveChanges();
                MessageBox.Show("Изменения успешно сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изменений: {ex.Message}");
            }
        }
    }
}
