namespace ClassLibraryEmloyees
{
    public class HeadOfDivision : Person, ITitlable
    {
        private string nameofDivision;
        private string NameofDivision { get => nameofDivision; set => nameofDivision = value; }
        public string getTitle()
        {
            return "Руководитель подразделения";
        }
    }

   
}
