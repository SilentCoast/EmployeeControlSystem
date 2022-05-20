using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ClassLibEmployees;

namespace PersonalUchet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   

        ApplicationContex db;
        
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContex();
            db.Transfers.Load();

            listViewEmployees.ItemsSource = db.Transfers.Local.ToBindingList();


        }

        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow();
            if (addNewEmployeeWindow.ShowDialog().Value)
            {
                db.Transfers.Add(addNewEmployeeWindow.getNewEmployee());

            }

            //resize columns as max element's width
            foreach (GridViewColumn c in gridViewMain.Columns)
            {
                if (double.IsNaN(c.Width))
                {
                    c.Width = c.ActualWidth;
                }
                c.Width = double.NaN;
            }
        }

        private void btnDeleteSelectedEmployees_Click(object sender, RoutedEventArgs e)
        {
            
            
            
        }
    }
}
