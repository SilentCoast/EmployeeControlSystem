using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEmloyees
{
    public class Person
    {
        private string FIO { get; set; }
        private string Sex { get; set; }
        private string BirthDate { get; set; }

        public void setFIO(string newfio) 
        {
            try
            {
                FIO = newfio;
            }
            catch (FormatException) { }
        }

    }

   
}
