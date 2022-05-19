namespace ClassLibraryEmployees
{
    public class Director : Person, ITitlable
    {

        public string getTitle()
        {
            return "Директор";
        }
    }

   
}
