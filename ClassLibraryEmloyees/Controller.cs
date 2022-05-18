namespace ClassLibraryEmloyees
{
    class Controller : Person, ITitlable
    {
        public string getTitle()
        {
            return "Контроллер";
        }
    }

   
}
