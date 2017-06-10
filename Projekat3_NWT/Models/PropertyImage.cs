using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class PropertyImage
    {
        public long Id { get; set; }
        public string description { get; set; }
        public string url { get; set; }

        public virtual Property Property { get; set; }
    }
}