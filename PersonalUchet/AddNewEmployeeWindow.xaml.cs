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
using System.Windows.Shapes;
using ClassLibEmployees;

namespace PersonalUchet
{
    /// <summary>
    /// Interaction logic for AddNewEmployeeWindow.xaml
    /// </summary>
    public partial class AddNewEmployeeWindow : Window
    {
        private Transfer transfer;
        
        public AddNewEmployeeWindow(Transfer transfer)
        {
            InitializeComponent();
            this.transfer = transfer;
            if (transfer.Sex != null)
            {
                if (transfer.Sex.Equals("Мужчина"))
                {
                    radioButtonMan.IsChecked = true;
                }
                else if (transfer.Sex.Equals("Женщина"))
                {
                    radioButtonWoman.IsChecked = true;
                }
            }
            DataContext = transfer;
      
            comboBoxTitle.ItemsSource=new List<string>() { "Директор","Руководитель подразделения","Контроллёр","Рабочий"};
            
        }

        

 

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            transfer.FIO = txtFIO.Text;

            transfer.BirthDate = txtBirthDate.Text;


            transfer.UnicProperty =  txtUnicProperty.Text;

            transfer.Title = comboBoxTitle.Text;
            

            if (radioButtonMan.IsChecked == true)
            {
                transfer.Sex = "Мужчина";
            }
            else if(radioButtonWoman.IsChecked == true)
            {
                transfer.Sex = "Женщина";
            }


            DialogResult = true;
            
            Close();
        }
        public Transfer getNewEmployee()
        {
            return transfer;
        }
    }
}
