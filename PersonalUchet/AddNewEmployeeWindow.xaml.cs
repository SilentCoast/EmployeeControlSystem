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
        Transfer transfer = new Transfer();
        
        public AddNewEmployeeWindow()
        {
            InitializeComponent();
            ShowingAdditionalProperty(false);
            comboBoxPositionInCompany.ItemsSource=new List<string>() { "Директор","Руководитель подразделения","Контроллёр","Рабочий"};
            
        }

        private void comboBoxPositionInCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            //Если выбран руководитель или рабочий показываем доп поля
            switch (comboBox.SelectedIndex)
            {
                //case director
                case 0:
                    ShowingAdditionalProperty(false);
                    break;
                //case rukovoditel
                case 1:
                    ShowingAdditionalProperty(true);
                    lblUnicProperty.Content = "Название подразделения";
                    break;
                // case controller
                case 2:
                    ShowingAdditionalProperty(false);
                    break;
                //case rabochiy
                case 3:
                    ShowingAdditionalProperty(true);
                    lblUnicProperty.Content = "Имя руководителя";
                    break;
                
                
            }
            
        }
        /// <summary>
        /// Задаёт Visibility полей для доп информации о работнике
        /// </summary>
        /// <param name="answer"></param>
        private void ShowingAdditionalProperty(bool answer)
        {
            if (answer)
            {
                txtUnicProperty.Visibility = Visibility.Visible;
                lblUnicProperty.Visibility = Visibility.Visible;
            }
            else
            {
                txtUnicProperty.Visibility = Visibility.Hidden;
                lblUnicProperty.Visibility = Visibility.Hidden;
            }
        }

 

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            transfer.FIO = txtFIO.Text;
            transfer.BirthDate = txtBirthDate.Text;
            if(radioButtonMan.IsChecked == true)
            {
                transfer.Sex = "Мужчина";
            }
            else if(radioButtonWoman.IsChecked == true)
            {
                transfer.Sex = "Женщина";
            }
            transfer.UnicProperty = lblUnicProperty.Content +" : "+ txtUnicProperty.Text;

            transfer.PositionInCompany = comboBoxPositionInCompany.Text;
            DialogResult = true;
            
            Close();
        }
        public Transfer getNewEmployee()
        {
            return transfer;
        }
    }
}
