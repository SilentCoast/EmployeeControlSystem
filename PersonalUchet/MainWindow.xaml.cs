using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
            //initialize database
            db = new ApplicationContex();
            db.Transfers.Load();

            listViewEmployees.ItemsSource = filters;

            //Фильтры
            comboBoxTitleFilters.ItemsSource = new List<string>() { "Должности","Директор", "Руководитель подразделения", "Контроллёр", "Рабочий" };

            comboBoxDivisionFilters.ItemsSource = new List<string>() { "Подразделения", "Петрово","Лужайкино"};

            //по умолчанию без фильтров
            comboBoxTitleFilters.SelectedIndex = 0;
            comboBoxDivisionFilters.SelectedIndex = 0;
            
            doFilters();
        }

        private void btnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmployeeWindow addNewEmployeeWindow = new AddNewEmployeeWindow(new Transfer());
            if (addNewEmployeeWindow.ShowDialog().Value)
            {

                db.Transfers.Add(addNewEmployeeWindow.getNewEmployee());
                filters.Add(addNewEmployeeWindow.getNewEmployee());
                db.SaveChanges();
            }
            doFilters();
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
            doFilters();
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

       

        private void btnApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            doFilters();
        }

        /// <summary>
        ///обновляет listView по заданным фильтрам
        /// </summary>
        public void doFilters()
        {
            foreach (Transfer transfer in db.Transfers)
            {
                if (transfer.Division == comboBoxDivisionFilters.Text || comboBoxDivisionFilters.Text == "Подразделения")
                {
                    if (transfer.Title == comboBoxTitleFilters.Text || comboBoxTitleFilters.Text == "Должности")
                    {
                        if (!filters.Contains(transfer))
                        {
                            filters.Add(transfer);
                        }
                        continue;
                    }
                }
                filters.Remove(transfer);
            }
            if(filters.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов");
                comboBoxTitleFilters.SelectedIndex = 0;
                comboBoxDivisionFilters.SelectedIndex = 0;
                doFilters();
            }
        }

        private void btnOffFilters_Click(object sender, RoutedEventArgs e)
        {
            comboBoxTitleFilters.SelectedIndex = 0;
            comboBoxDivisionFilters.SelectedIndex = 0;
            doFilters();
        }
    }
}
