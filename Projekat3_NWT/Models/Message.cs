using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Message
    {

        public long Id { get; set; }

        [Required]
        [Display(Name = "First and Last Name")]
        public string UserFullName { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Display(Name = "Date Sent")]
        public DateTime DateSent { get; set; }

        public bool Answered { get; set; }

        public string Answer { get; set; }
    }
}