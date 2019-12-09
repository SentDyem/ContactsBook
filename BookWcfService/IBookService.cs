using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookWcfService
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        IEnumerable<Contact> GetContacts();
        [OperationContract]
        void InsertContact(Contact cobj);
        [OperationContract]
        void UpdateContact(Contact cobj);
        [OperationContract]
        void DeleteContact(int Id);
    }
    [DataContract]
    public class Contact
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string Name { get; set; }
        [DataMember]
        [Required]
        public string Email { get; set; }

    }
}
