using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Xml.Linq;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для DataBlock.xaml
    /// </summary>
    public partial class MyRecord : Page
    {
        private int id;
        private int idclients;

        public MyRecord(int idrecord)
        {
            InitializeComponent();
            id = idrecord;           


           DGridRecords.ItemsSource = AutoLandDB.GetContext().Record.ToList();
            
            decimal sum = GetTotalSum();
            TotalPreis.Text = $"Стоимость услуг:  {sum}";


        }


        private decimal GetTotalSum()
        {
            decimal sum = 0;

            using (var context = new AutoLandDB())
            {
                sum = (decimal) AutoLandDB.GetContext().Record.ToList().Where(p => p.Id_client == id).Sum(p => p.Preic);           
            }

            return sum;
        }



        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            
            var rec = DGridRecords.SelectedItems.Cast<Record>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить свою запись?" ,"Alarm" , MessageBoxButton.YesNo,MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                AutoLandDB.GetContext().Record.RemoveRange(rec);

                AutoLandDB.GetContext().SaveChanges();
                MessageBox.Show("Вы удалили");
                DGridRecords.ItemsSource = AutoLandDB.GetContext().Record.ToList().Where(p => p.Id_client == id);
                decimal sum = GetTotalSum();
                TotalPreis.Text = $"Стоимость услуг:  {sum}";
            }
          

        }

       private void DGridRecords_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
       {
            if (Visibility == Visibility.Visible)
                {
                    AutoLandDB.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridRecords.ItemsSource = AutoLandDB.GetContext().Record.ToList().Where(p => p.Id_client == id);
                }
           
        }

        private void DGridRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
       
    }
}
