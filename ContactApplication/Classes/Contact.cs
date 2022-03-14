using SQLite;

namespace ContactApplication.Classes
{
    public class Contact
    {
        //Contact class met properties.
        [PrimaryKey, AutoIncrement]
        //AutoIncrement zorgt ervoor dat ID altijd uniek is.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name} - {Email} - {Telephone}".ToString();
        //}
        //Databinding
        //Class (bron) - binding - UI (doel)

    }
}
