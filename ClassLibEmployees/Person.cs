using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibEmployees
{
    public class Person : INotifyPropertyChanged
    {
        private string fIO;
        private string sex;
        private string birthDate;
        private int id;

        public int Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FIO
        {
            get => fIO; set
            {
                fIO = value;
                OnPropertyChanged("FIO");
            }
        }
        public string Sex
        {
            get => sex; set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public string BirthDate
        {
            get => birthDate; set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }


}
