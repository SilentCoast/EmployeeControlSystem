namespace ClassLibraryEmployees
{
    public class Rabochiy : Person, ITitlable
    {
        private string fIOofHeadofDivision;

        public string FIOofHeadofDivision
        {
            get => fIOofHeadofDivision; set
            {
                fIOofHeadofDivision = value;
                OnPropertyChanged("FIOofHeadofDivision");
            }
        }
        public string getTitle()
        {
            return "Рабочий";
        }
    }

   
}
