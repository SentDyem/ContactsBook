using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

    }
}