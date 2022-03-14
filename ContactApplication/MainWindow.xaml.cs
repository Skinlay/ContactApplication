using ContactApplication.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ContactApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring contacts object from class Contact
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            //Object contacts to new list made from class Contact
            contacts = new List<Contact>();
            //Opening & refreshing database
            ReadDatabase();

        }

        //opent NewContactWindow
        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            //Button event that opens NewContactWindow
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            Close();
            ReadDatabase();
        }

        void ReadDatabase()
        {
            //Connect and read from database
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.strDatabasePath))
            {
                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList());
            }
            //Show contacts in listview element
            if (contacts != null)
            {
                contactsList.ItemsSource = contacts;
            }
        }

        // werkt niet
        //filter
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Searchbar and filtered list.
            //TextBox searchTextBox = sender as TextBox;
            //var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            //contactsList.ItemsSource = filteredList;
        }


        //opens to eddit window
        private void contactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectionChanged event that opens ContactDetailsWindow
            Contact selectedContact = (Contact)contactsList.SelectedItem;
            //Each time an item is selected, show the ContactDetailsWindow of that item (item = contact)
            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog(); //Code awaits interaction
                ReadDatabase(); //Refresh database in ListView element
            }
        }
    }
}
