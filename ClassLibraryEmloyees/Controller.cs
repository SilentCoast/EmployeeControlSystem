namespace ClassLibraryEmloyees
{
    public class Controller : Person, ITitlable
    {
        public string getTitle()
        {
            return "Контроллер";
        }
    }

   
}
