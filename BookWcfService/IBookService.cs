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
        IEnumerable<Contact> Get();
        [OperationContract]
        void Insert(Contact cobj);
        [OperationContract]
        void Update(Contact cobj);
        [OperationContract]
        void Delete(int Id);
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
        [EmailAddress(ErrorMessage = "Введите корректный Email адрес")]
        public string Email { get; set; }

    }
}
