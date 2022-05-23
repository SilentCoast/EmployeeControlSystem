using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibEmployees
{
    /// <summary>
    /// Class that puts into ListBox
    /// </summary>
    public class Transfer : INotifyPropertyChanged
    {
        private int id;
        private string fIO;
        private string sex;
        private string birthDate;
        private string title;
        private string unicProperty;

        public int ID
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string FIO
        {
            get => fIO; set
            {
                fIO = value;
                OnPropertyChanged();
            }
        }
        public string Sex
        {
            get => sex; set
            {
                sex = value;
                OnPropertyChanged();
            }
        }
        public string BirthDate
        {
            get => birthDate; set
            {
                birthDate = value;
                OnPropertyChanged();
            }
        }
        public string Title
        {
            get => title; set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public string UnicProperty
        {
            get => unicProperty; set
            {
                unicProperty = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
