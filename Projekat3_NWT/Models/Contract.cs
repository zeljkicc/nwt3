using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Contract
    {
        public long Id { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Content")]
        public string content { get; set; }
    }
}