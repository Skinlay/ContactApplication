using ContactApplication.Classes;
using SQLite;
using System.Windows;

namespace ContactApplication
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            //Initialising window
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Connection to class
            Contact contact = new Contact()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Telephone = txtTelephone.Text
            };
            //Connection to database
            using SQLiteConnection connection = new SQLiteConnection(App.strDatabasePath);
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            //Close current window
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Close current window
            Close();
        }
    }
}
