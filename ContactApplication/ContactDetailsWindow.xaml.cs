using ContactApplication.Classes;
using SQLite;
using System.Windows;

namespace ContactApplication
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact contact;
        public ContactDetailsWindow(Contact contact)
        {
            //Initialising window
            InitializeComponent();

            //Loading contact in Window
            this.contact = contact;
            txtName.Text = contact.Name;
            txtTelephone.Text = contact.Telephone;
            txtEmail.Text = contact.Email;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Update existing contact
            contact.Name = txtName.Text;
            contact.Telephone = txtTelephone.Text;
            contact.Email = txtEmail.Text;


            //Connection to database
            using SQLiteConnection connection = new SQLiteConnection(App.strDatabasePath);
            {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Deleting an existing contact from database.
            using SQLiteConnection conn = new SQLiteConnection(App.strDatabasePath);
            {
                conn.CreateTable<Contact>();
                conn.Delete(contact);
            }
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Close current window
            Close();
        }
    }
}
