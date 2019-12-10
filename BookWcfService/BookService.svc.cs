using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookWcfService
{
    public class BookService : IBookService
    {
        public void Delete(int Id)
        {
            ContactContext db = new ContactContext();
            var c = (from con in db.Contacts    // определение каждого объекта
                     where con.Id == Id        // фильтрация по ид
                     select con).First();      // выбор объекта 
            db.Contacts.Remove(c);
            db.SaveChanges();
        }

        public IEnumerable<Contact> Get()
        {
            List<Contact> list = new List<Contact>();
            ContactContext db = new ContactContext();
            list = db.Contacts.ToList();
            return list;
        }

        public void Insert(Contact cobj)
        {
            ContactContext db = new ContactContext();
            db.Contacts.Add(cobj);
            db.SaveChanges();
            
        }

        public void Update(Contact cobj)
        {
            ContactContext db = new ContactContext();
            var c = (from con in db.Contacts
                     where con.Id == cobj.Id
                     select con).First();
            c.Name = cobj.Name;
            c.Email = cobj.Email;
            db.SaveChanges();
        }
    }
}
