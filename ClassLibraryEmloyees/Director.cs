namespace ClassLibraryEmloyees
{
    public class Director : Person, ITitlable
    {

        public string getTitle()
        {
            return "Директор";
        }
    }

   
}
