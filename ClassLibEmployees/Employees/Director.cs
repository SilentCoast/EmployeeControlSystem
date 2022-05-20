namespace ClassLibEmployees
{
    public class Director : Person, ITitlable
    {
        private const string title = "Директор";
        public string Title { get { return title; }  }

        public string getTitle()
        {
            return "Директор";
        }
    }

   
}
