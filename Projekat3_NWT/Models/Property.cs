using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Property
    {
        public long Id { get; set; }

        [Display(Name = "Type of Property")]
        public string Type { get; set; }

        [Display(Name = "Available For")]
        public string AvailableFor { get; set; }

        [Display(Name = "Added On")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Rooms")]
        public int NumberOfRooms { get; set; }

        [Display(Name = "Bedrooms")]
        public int NumberOfBedRooms { get; set; }

        [Display(Name = "Bathrooms")]
        public int NumberOfBathRooms { get; set; }

        [Display(Name = "SquareMeters")]
        public double SquareMeters { get; set; }

        [Display(Name = "Long Description")]
        public string DescriptionLong { get; set; }

        [Display(Name = "Short Description")]
        public string DescriptionShort { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Story Number")]
        public int StoryNumber { get; set; }

        [Display(Name = "Total Number of Stories")]
        public int TotalNumberOfStories { get; set; }

        [Display(Name = "Heating")]
        public string TypeOfHeating { get; set; }

        [Display(Name = "Parking Place")]
        public bool ParkingPlace { get; set; }

        [Display(Name = "Available From")]
        public DateTime AvailableFrom { get; set; }

        [Display(Name = "Elevator")]
        public bool Elevator { get; set; }

        [Display(Name = "Camera System")]
        public bool CameraSystem { get; set; }

        [Display(Name = "Interphone")]
        public bool InterPhone { get; set; }

        [Display(Name = "Furnished")]
        public bool Furnished { get; set; }

        public bool available { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual Address Address { get; set; }

        //public virtual Address address { get; set; }
        //public virtual Owner owner { get; set; }
        //public virtual Agent agent { get; set; }
        //public virtual IEnumerable<PropertyPicture> pictures { get; set; }

        public virtual ICollection<PropertyImage> propertyImages { get; set; }

        public Property()
        {
            propertyImages = new List<PropertyImage>();
            available = true;
        }

        
    }
}