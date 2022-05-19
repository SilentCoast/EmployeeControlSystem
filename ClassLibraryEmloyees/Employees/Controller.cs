namespace ClassLibraryEmployees
{
    public class Controller : Person, ITitlable
    {
        public string getTitle()
        {
            return "Контроллер";
        }
    }

   
}
