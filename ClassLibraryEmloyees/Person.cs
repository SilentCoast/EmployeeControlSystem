using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmloyees
{
    public class Person
    {
        private string sex;
        private string birthDate;
        private string fIO;

        protected string FIO { get => fIO; set => fIO = value; }
        protected string Sex { get => sex; set => sex = value; }
        protected string BirthDate { get => birthDate; set => birthDate = value; }
    }

   
}
