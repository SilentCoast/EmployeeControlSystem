using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ClassLibraryEmployees;

namespace PersonalUchet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   ObservableCollection<Transfer> listOfEmployees;
        public MainWindow()
        {
            InitializeComponent();
            listOfEmployees = new ObservableCollection<Transfer>();
            Transfer rabochiy = new Transfer();
            rabochiy.FIO = "Иванов Иван Иванович";
            rabochiy.BirthDate = "03.12.2000";
            rabochiy.Sex = "Мужчина";
            listOfEmployees.Add(rabochiy);
            
            listBoxEmployees.ItemsSource = listOfEmployees;

            


        }

        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            if (!addNewEmployeeWindow.ShowDialog().Value)
            {
                
                
                listOfEmployees.Add(addNewEmployeeWindow.getNewEmployee());

            }
            

        }

 

 
    }
}
