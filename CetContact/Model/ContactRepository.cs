using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetContact.Model
{
    public class ContactRepository
    {

        public ContactRepository() { }

        public List<ContactInfo> GetAllContacts () { 
            return new List<ContactInfo> ();
        }
        public void AddContact (ContactInfo contact)
        {

        }
    }
}
