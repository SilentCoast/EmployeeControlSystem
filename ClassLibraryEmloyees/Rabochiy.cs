namespace ClassLibraryEmloyees
{
    public class Rabochiy : Person, ITitlable
    {
        private string fIOofHeadofDivision;

        public string FIOofHeadofDivision { get => fIOofHeadofDivision; set => fIOofHeadofDivision = value; }
        public string getTitle()
        {
            return "Рабочий";
        }
    }

   
}
