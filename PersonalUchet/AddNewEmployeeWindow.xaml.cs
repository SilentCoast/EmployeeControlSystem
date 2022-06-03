using System.Collections.Generic;
using System.Windows;
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
            comboBoxDivision.ItemsSource = new List<string>() { "Петрово", "Лужайкино" };
        }

        

 

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            transfer.FIO = txtFIO.Text;

            transfer.BirthDate = txtBirthDate.Text;


            transfer.UnicProperty =  txtUnicProperty.Text;

            transfer.Title = comboBoxTitle.Text;

            transfer.Division = comboBoxDivision.Text;

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
