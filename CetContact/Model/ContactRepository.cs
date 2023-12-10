
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetContact.Model
{
    public class ContactRepository
    {
        private SQLiteAsyncConnection database;
        private string databaseName = "contacts2.db3";


        public ContactRepository() {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ContactInfo>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();
        }
       
       
        public async Task<ObservableCollection<ContactInfo>> GetAllContacts () { 
            var allContacts = await database.Table<ContactInfo>().ToListAsync();
            var allObservableContacts = new ObservableCollection<ContactInfo>();
            foreach (var contact in allContacts)
            {
                allObservableContacts.Add(contact);
            }
            return allObservableContacts;

        }
        public async Task AddContact (ContactInfo contact)
        {
            await database.InsertAsync(contact);
        
        }

        public async Task<ContactInfo> GetContactById(int Id)
        {
            var contact = await database.Table<ContactInfo>().Where(c => c.Id == Id).FirstOrDefaultAsync();
            return contact;
        }

        public async Task Update(ContactInfo contact)
        {
            await database.UpdateAsync(contact);
        }

        public async Task RemoveContact(ContactInfo contact)
        {
            await database.DeleteAsync(contact);
        }

        public async Task<ObservableCollection<ContactInfo>> SearchContacts(string searchText)
        {
            var allContacts = await database.Table<ContactInfo>().ToListAsync();
            var allObservableContacts = new ObservableCollection<ContactInfo>();
            foreach (var contact in allContacts)
            {
                allObservableContacts.Add(contact);
            }
            var searchedContacts =new ObservableCollection<ContactInfo>(allObservableContacts.Where(x => x.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList());
            return searchedContacts;
        }
    }
}
