using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
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
        ObservableCollection<Transfer> filters;
        
        public MainWindow()
        {
            InitializeComponent();

            //колекция для передачи в listView
            filters = new ObservableCollection<Transfer>();

            //чтобы программа видела базу данных(поднимаемся из Debug в PersonalUchet)
            Directory.SetCurrentDirectory(@"..\..\");
            
            db = new ApplicationContex();
            db.Transfers.Load();
        
            listViewEmployees.ItemsSource = filters;

            comboBoxTitleFilters.ItemsSource = new List<string>() { "Все","Директор", "Руководитель подразделения", "Контроллёр", "Рабочий" };
            //по умолчанию "все", прописываем здесь чтобы тригернуть SelectionChanged и прогрузить данные в listView
            comboBoxTitleFilters.SelectedIndex = 0;

            comboBoxDivisionFilters.ItemsSource = new List<string>() { "Подразделения", "Петрово","Лужайкино"};

            comboBoxDivisionFilters.SelectedIndex = 0;
        }

        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow(new Transfer());
            if (addNewEmployeeWindow.ShowDialog().Value)
            {

                db.Transfers.Add(addNewEmployeeWindow.getNewEmployee());
                filters.Add(addNewEmployeeWindow.getNewEmployee());
                //TODO: when adding new employee, it displays in the listView whether or not filters was set
                db.SaveChanges();
            }
            ResizeColumns();
        }

        private void btnDeleteSelectedEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (listViewEmployees.SelectedItem == null) return;
            Transfer transfer = listViewEmployees.SelectedItem as Transfer;
            db.Transfers.Remove(transfer);
            filters.Remove(transfer);
            db.SaveChanges();
            ResizeColumns();
        }

        private void btnEditSelectedEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(listViewEmployees.SelectedItem == null) return;
            Transfer transfer = (Transfer)listViewEmployees.SelectedItem;

            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow(new Transfer() 
            { 
                FIO = transfer.FIO,
                BirthDate = transfer.BirthDate,
                Sex = transfer.Sex,
                Title = transfer.Title,
                UnicProperty = transfer.UnicProperty,
                ID = transfer.ID,
                Division = transfer.Division
            });
            addNewEmployeeWindow.btnAddEmployee.Content = "Редактировать сотрудника";
            if (addNewEmployeeWindow.ShowDialog().Value)
            {
                transfer = db.Transfers.Find(transfer.ID);
                if (transfer != null)
                {
                    transfer.FIO = addNewEmployeeWindow.getNewEmployee().FIO;
                    transfer.BirthDate = addNewEmployeeWindow.getNewEmployee().BirthDate;
                    transfer.Sex = addNewEmployeeWindow.getNewEmployee().Sex;
                    transfer.Title = addNewEmployeeWindow.getNewEmployee().Title;
                    transfer.UnicProperty = addNewEmployeeWindow.getNewEmployee().UnicProperty;
                    transfer.ID = addNewEmployeeWindow.getNewEmployee().ID;
                    transfer.Division = addNewEmployeeWindow.getNewEmployee().Division;
                    db.Entry(transfer).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            ResizeColumns();
        }

        /// <summary>
        /// resize columns as max element's width
        /// </summary>
        private void ResizeColumns()
        {
            
            foreach (GridViewColumn c in gridViewMain.Columns)
            {
                if (double.IsNaN(c.Width))
                {
                    c.Width = c.ActualWidth;
                }
                c.Width = double.NaN;
            }
        }

        private void comboBoxFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch(comboBoxTitleFilters.SelectedIndex) 
            {
                //все (нет фильтра)
                case 0:
                    foreach(Transfer i in db.Transfers)
                    {
                        if (!filters.Contains(i))
                        {
                            filters.Add(i);
                        }
                        
                    }
                    
                    break;
                    
                case 1:
                    foreach (Transfer i in db.Transfers)
                    {
                        if (i.Title != null)
                        { 
                            if (i.Title == "Директор") 
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            } 
                        }
                        filters.Remove(i);
                    }
                    break;

                case 2:
                    foreach (Transfer i in db.Transfers)
                    {
                        if (i.Title != null)
                        {
                            if (i.Title == "Руководитель подразделения")
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            }
                        }
                        filters.Remove(i);
                    }
                    break;
                case 3:
                    foreach (Transfer i in db.Transfers)
                    {
                        if (i.Title != null)
                        {
                            if (i.Title == "Контроллёр")
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            }
                        }
                        filters.Remove(i);
                    }
                    break;
                case 4:
                    foreach (Transfer i in db.Transfers)
                    {
                        if (i.Title != null)
                        {
                            if (i.Title == "Рабочий")
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            }
                        }
                        filters.Remove(i);
                    }
                    break;
            }
            ResizeColumns();
        }

        private void comboBoxDivisionFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Transfer i in db.Transfers)
            {
                switch (comboBoxDivisionFilters.SelectedIndex)
                {
                    case 0:
                        if (!filters.Contains(i))
                        {
                            filters.Add(i);
                        }
                        continue;
                        
                    case 1:
                        if (i.Division != null)
                        {
                            if(i.Division == "Петрово")
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            }
                        }
                        break;
                    case 2:
                        if (i.Division != null)
                        {
                            if (i.Division == "Лужайкино")
                            {
                                if (!filters.Contains(i))
                                {
                                    filters.Add(i);
                                }
                                continue;
                            }
                        }
                        break;
                }
                filters.Remove(i);
            }
        }
    }
}
