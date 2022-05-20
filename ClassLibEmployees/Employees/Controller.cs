namespace ClassLibEmployees
{
    public class Controller : Person, ITitlable
    {
        public string getTitle()
        {
            return "Контроллер";
        }
    }

   
}
