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
    {   ObservableCollection<Person> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<Person>();
            Rabochiy rabochiy = new Rabochiy();
            rabochiy.FIO = "sdf";
            rabochiy.BirthDate = "dsf";
            rabochiy.Sex = "m";
            rabochiy.FIOofHeadofDivision = "sPE";
            list.Add(rabochiy);
            list.Add(rabochiy);
            listBoxEmployees.ItemsSource = list;




        }

        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            if (!addNewEmployeeWindow.ShowDialog().Value)
            {
                
                MessageBox.Show(addNewEmployeeWindow.getNewEmployee().ToString());
                list.Add(addNewEmployeeWindow.getNewEmployee());

            }
            

        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            
        }
    }
}
