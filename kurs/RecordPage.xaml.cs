using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        private int id;
        private int idclient;
        public RecordPage(int iduser, int idclients)
        {
            InitializeComponent();
            id = iduser;
            idclient = idclients;
          
                NameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Name;
                SecondNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).SecondName;
                LastNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).LastName;
                PhoneTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Phone;

         }
        private void CalculatePrice()
        {
            Preic preic = new Preic();

            string savetext = "";
            if (Item1.IsSelected == true)
            {
                savetext = Choice2Box.Text;
            }
            else
            {
                savetext = Choice21Box.Text;
            }

            for (int i = 0; i < preic.name.Length; i++)
            {
                if (savetext == preic.name[i])
                {
                    PreisUsl.Text = "Стоимость услуги " + preic.preis[i];
                    break;
                }
            }
        }

        public Visibility Visible { get; private set; }
        public Visibility Hidden { get; private set; }

        private void ChoiceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Name;
            SecondNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).SecondName;
            LastNameTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).LastName;
            PhoneTb.Text = AutoLandDB.GetContext().Client.FirstOrDefault(p => p.Id_user == id).Phone;

            if (Item1.IsSelected == true)
            {
                Choice2Box.Visibility = Visible;
                StackRecord.Visibility = Visible;
                Choice21Box.Visibility = Visibility.Collapsed;
                Item2.IsSelected = false;
            }
            else if (Item2.IsSelected == true)
            {
                Choice21Box.Visibility = Visible;
                Choice2Box.Visibility = Visibility.Collapsed;
                StackRecord.Visibility = Visible;
                Item1.IsSelected = false;
            }         
           
        }



        private void Choice2Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Choice2Box.Items.Count != 0)
            {
                btnRecord.Visibility = Visibility.Visible;
            }
        }



        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Preic preic = new Preic();

            string savetext = "";
            if (Item1.IsSelected == true)
            {
               savetext = Choice2Box.Text;
               
            }
            else
            {
                savetext = Choice21Box.Text;
         
            }
            for (int i = 0; i < preic.name.Length; i++)
            {
                if (savetext == preic.name[i])
                {
                    MessageBox.Show("Вы успешно записались на "+ preic.name[i]);
                    AutoLandDB.GetContext().Record.Add(new Record { Id_client = idclient, Datetime = Convert.ToDateTime(DTPicker.Text.Trim()), Service = savetext, Preic = preic.preis[i] });
                }              
            }              
            Manager.MainFrame.Navigate(new Home());
            AutoLandDB.GetContext().SaveChanges();
        }

        private void DTPicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(DTPicker.DataContext != null)
            {
                btnRecord.Visibility = Visibility.Visible;
            }
            else
            {
                btnRecord.Visibility = Visibility.Collapsed;
            }
        }

        private void DTPicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(DTPicker.Text != null)
            {
                btnRecord.Visibility = Visibility.Visible;
            }
            else
            {
                btnRecord.Visibility = Visibility.Collapsed;
            }
            CalculatePrice();
        }

    }
}
