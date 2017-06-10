using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Address
    {
        public long Id { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        
        public string ZipCode { get; set; }

        public double Lon { get; set; }

        public double Lat { get; set; }

    }
}