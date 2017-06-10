using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekat3_NWT.DAL;
using Projekat3_NWT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq.Expressions;
using PredicateExtensions;
using System.IO;
using System.Threading.Tasks;
using PagedList;

namespace Projekat3_NWT.Controllers
{
    public class PropertyController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Properties
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            IEnumerable<Property> properties = unitOfWork.PropertyRepository.GetAll().Where(p=>p.available == true);
            if (String.IsNullOrEmpty(sortOrder))
            {
                properties = properties.OrderByDescending(p => p.DateAdded);
                ViewBag.SortParm = "date_desc";
            }
            else
            {
                switch (sortOrder)
                {
                    case "date_asc":
                        properties = properties.OrderBy(p => p.DateAdded);
                        ViewBag.SortParm = "date_asc";
                        break;

                    case "availablefor_desc":
                        properties = properties.OrderByDescending(p => p.AvailableFor);
                        ViewBag.SortParm = "availablefor_desc";
                        break;

                    case "availablefor_asc":
                        properties = properties.OrderBy(p => p.AvailableFor);
                        ViewBag.SortParm = "availablefor_asc";
                        break;

                    case "type_desc":
                        properties = properties.OrderByDescending(p => p.Type);
                        ViewBag.SortParm = "type_desc";
                        break;

                    case "type_asc":
                        properties = properties.OrderBy(p => p.Type);
                        ViewBag.SortParm = "type_asc";
                        break;

                    case "rooms_desc":
                        properties = properties.OrderByDescending(p => p.NumberOfRooms);
                        ViewBag.SortParm = "rooms_desc";
                        break;

                    case "rooms_asc":
                        properties = properties.OrderBy(p => p.NumberOfRooms);
                        ViewBag.SortParm = "rooms_asc";
                        break;

                    case "squaremeters_desc":
                        properties = properties.OrderByDescending(p => p.SquareMeters);
                        ViewBag.SortParm = "squaremeters_desc";
                        break;

                    case "squaremeters_asc":
                        properties = properties.OrderBy(p => p.SquareMeters);
                        ViewBag.SortParm = "squaremeters_asc";
                        break;

                    case "price_desc":
                        properties = properties.OrderByDescending(p => p.Price);
                        ViewBag.SortParm = "price_desc";
                        break;

                    case "price_asc":
                        properties = properties.OrderBy(p => p.Price);
                        ViewBag.SortParm = "price_asc";
                        break;
                }
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(properties.ToPagedList(pageNumber, pageSize));
        }

        
        public ActionResult List(string availableFor, bool newest)
        {
            

            Expression<Func<Property, bool>> predicate = null;

            if (availableFor != null)
            predicate = p => p.AvailableFor == availableFor;

            IEnumerable<Property> properties = null;
            if (predicate != null)
                properties = unitOfWork.PropertyRepository.Find(predicate);
            else properties = unitOfWork.PropertyRepository.GetAll();

            if (newest)
            {
                properties = properties.OrderByDescending(p => p.DateAdded);
            }


            var sortOrderItems = new SelectList(new[]
                           {
                                new { Value = "date_desc", Text = "First New" },
                                new { Value = "date_asc", Text = "First Last" },

                                new { Value = "price_desc", Text = "First Highest Price" },
                                new { Value = "price_asc", Text = "First Lowest Price" },

                                new { Value = "square_meters_desc", Text = "First Most Square Meters" },
                                new { Value = "square_meters_asc", Text = "First Less Square Meters" }
                            },
                           "Value", "Text", 1);

            ViewData["SortOrderItems"] = sortOrderItems;

            ViewBag.AvailableFor = availableFor;


            return View(properties.Where(p=>p.available == true).Take(5));
        }

        [HttpPost]
        public ActionResult List(string sortOrder, double priceMin, double priceMax, double metersMin, double metersMax,
            int roomsMin, int roomsMax, string Furnished, string type, int? blocks, string availableFor)
        {
           
            //= unitOfWork.PropertyRepository.GetAll();

            Expression<Func<Property, bool>> predicate = null;
                


            if (priceMax > 0)
            {
                if(predicate == null)
                {
                    predicate = p => p.Price >= priceMin && p.Price <= priceMax;
                }
                else
                {
                    predicate = predicate.And(p => p.Price >= priceMin && p.Price <= priceMax);
                }

  
                
            }
            //var properties = unitOfWork.PropertyRepository.GetAll();
            if (metersMax > 0)
            {
                if(predicate != null)
                {
                    predicate = predicate.And(p => p.SquareMeters >= metersMin && p.SquareMeters <= metersMax);
                }
                else
                {
                    predicate = p => p.SquareMeters >= metersMin && p.SquareMeters <= metersMax;
                }        
                
            }

            if (roomsMax > 0)
            {
                if (predicate != null)
                {
                    predicate = predicate.And(p => p.NumberOfRooms >= roomsMin && p.NumberOfRooms <= roomsMax);
                }
                else
                {
                    predicate = p => p.NumberOfRooms >= roomsMin && p.NumberOfRooms <= roomsMax;
                }

            }

            switch (Furnished)
            {
                case "All":
                    break;
                case "Yes":
                    if (predicate != null)
                        predicate = predicate.And(p => p.Furnished == true);
                    else predicate = p => p.Furnished == true;
                    break;
                case "No":
                    if(predicate != null)
                        predicate = predicate.And(p => p.Furnished == false);
                    else predicate = p => p.Furnished == false;
                    break;
            }

            if (type != "All")
            {

                        if (predicate != null)
                            predicate = predicate.And(p => p.Type == type);
                        else predicate = p => p.Type == type;
            }

          

            var properties = unitOfWork.PropertyRepository.GetAll();
            if (predicate != null)
                properties = unitOfWork.PropertyRepository.Find(predicate);


            if (properties.Count() == 0)
            {
                return PartialView("NoResultsPartial");
            }


            switch (sortOrder)
            {
                case "date_desc":
                    properties = properties.OrderByDescending(p => p.DateAdded);
                    break;
                case "date_asc":
                    properties = properties.OrderBy(p => p.DateAdded);
                    break;
                case "price_desc":
                    properties = properties.OrderByDescending(p => p.Price);
                    break;
                case "price_asc":
                    properties = properties.OrderBy(p => p.Price);
                    break;
                case "square_meters_desc":
                    properties = properties.OrderByDescending(p => p.SquareMeters);
                    break;
                case "square_meters_asc":
                    properties = properties.OrderBy(p => p.SquareMeters);
                    break;
            }

            ViewBag.AvailableFor = availableFor;

            int elements = (blocks ?? 0);
            if(availableFor != null)
            properties = properties.Where(p => p.available == true).Where(p => p.AvailableFor == availableFor).Skip(elements * 5).Take(5);
            else
            {
                properties = properties.Where(p => p.available == true).Skip(elements * 5).Take(5);
            }
            if (properties.Count() > 0)
                return PartialView("ListPartial", properties);
            else return PartialView("NoMoreResultsPartial");
        }

        public ActionResult ListPartialHomePage(bool newer, string availableFor)
        {
            IEnumerable<Property> properties = null;
            if(newer)
            properties = unitOfWork.PropertyRepository.GetAll().OrderByDescending(p => p.DateAdded).Take(5);

            if (availableFor != null)
                properties = unitOfWork.PropertyRepository.GetAll()
                    .OrderByDescending(p => p.DateAdded)
                    .Where(p => p.AvailableFor == availableFor && p.available == true).Take(5);

            if (properties != null)
                {
                    return PartialView("ListPartialHomePage", properties);
                }
                else return View();
        }

        // GET: Properties/Details/5
           public ActionResult Details(long? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Property property = unitOfWork.PropertyRepository.GetById(id);
                if (property == null)
                {
                    return HttpNotFound();
                }
                return View(property);
            }


        // GET: Properties/Create
        [Authorize]
        public ActionResult Create()
            {
            //za dropdown liste
            var typesOfProperty = new SelectList(new[]
                            {
                                new { Value = "House", Name = "House" },
                                new { Value = "Apartment", Name = "Apartment" }
                            },
                            "Value", "Name", 1);

            ViewData["TypeOfPropertyItems"] = typesOfProperty;

            var types = new SelectList(new[]
                           {
                                new { Value = "Rent", Text = "Rent" },
                                new { Value = "Sale", Text = "Sale" }
                            },
                           "Value", "Text", 1); 

            ViewData["AvailableForItems"] = types;

            var users = unitOfWork.ApplicationUserRepository.getAllClients();

            

            var sortOrderItems = new SelectList(users, "Id", "Email", 2);

            ViewData["UserItems"] = sortOrderItems;

            return View();
            }

            // POST: Properties/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [Authorize]
            [HttpPost]
            [ValidateAntiForgeryToken] //Proveriti Bind za adresu da li je dobar
            public ActionResult Create(Property property, Address address, IEnumerable<HttpPostedFileBase> files)
            {

            property.propertyImages = new List<PropertyImage>();
            if (ModelState.IsValid)
                {
                var folder = Server.MapPath("~/Images/user_uploads/" + User.Identity.Name);

                bool exists = Directory.Exists(folder);


                Directory.CreateDirectory(folder);
                //za fotografije
                int count = 0;
               
                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Images/user_uploads/" + User.Identity.Name), fileName);
                                file.SaveAs(path);
                                PropertyImage propertyImage = new PropertyImage();
                                propertyImage.url = "~/Images/user_uploads/" + User.Identity.Name + "/" + fileName;
                                propertyImage.description = "Proba";
                                //unitOfWork.PropertyImageRepository.Insert(propertyImage);

                                property.propertyImages.Add(propertyImage);
                                count++;
                            }
                        }                        

                    }
                
                    if(count == 0)
                    {
                    

                        PropertyImage propertyImage = new PropertyImage();
                        propertyImage.url = "~/Images/default.jpg";
                        propertyImage.description = "Proba";
                        //unitOfWork.PropertyImageRepository.Insert(propertyImage);

                        property.propertyImages.Add(propertyImage);
                    }



                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(unitOfWork.getDbContext()));
                if (User.IsInRole("Agent") || User.IsInRole("Admin"))
                {

                    ApplicationUser owner = UserManager.FindById(property.Owner.Id);
                    property.Owner = owner;
                }
                else
                {                    
                    ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                    property.Owner = currentUser;
                }
                

                    property.DateAdded = DateTime.Now;

                    //treba implementirati repository za adresu i dodati i adresu u bazy !!!!
                    unitOfWork.AddressRepository.Insert(address);

                    //postavljanje reference na adresu
                    property.Address = address;

                    
                    

                    unitOfWork.PropertyRepository.Insert(property);
                    unitOfWork.Save();
                if (User.IsInRole("Admin") || User.IsInRole("Agent"))
                    return RedirectToAction("Index");
                else return RedirectToAction("Index", "Home");
                }


            //u slucaju greske
            var typesOfProperty = new SelectList(new[]
                            {
                                new { Value = "House", Name = "House" },
                                new { Value = "Apartment", Name = "Apartment" }
                            },
                            "Value", "Name", 1);

            ViewData["TypeOfPropertyItems"] = typesOfProperty;

            var types = new SelectList(new[]
                           {
                                new { Value = "Rent", Text = "Rent" },
                                new { Value = "Sale", Text = "Sale" }
                            },
                           "Value", "Text", 1);

            ViewData["AvailableForItems"] = types;

            var users = unitOfWork.ApplicationUserRepository.getAllClients();



            var sortOrderItems = new SelectList(users, "Id", "Email", 2);

            ViewData["UserItems"] = sortOrderItems;

            ViewBag.ErrorMessage = "Fill all required fields and set the location of property";
            return View(property);
            }



        // GET: Properties/Edit/5
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Edit(long? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Property property = unitOfWork.PropertyRepository.GetById(id);

               if (property == null)
               {
                   return HttpNotFound();
               }
               return View( property );
           }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Edit(Property property, IEnumerable<HttpPostedFileBase> files)
          {
              if (ModelState.IsValid)
              {

                try {
                property.DateAdded = DateTime.Now;
                unitOfWork.PropertyRepository.Update(property);
                unitOfWork.AddressRepository.Update(property.Address);




                    int count = 0;

                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            if (file.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(file.FileName);
                                var path = Path.Combine(Server.MapPath("~/Images/user_uploads/" + User.Identity.Name), fileName);
                                file.SaveAs(path);
                                PropertyImage propertyImage = new PropertyImage();
                                propertyImage.url = "~/Images/user_uploads/" + User.Identity.Name + "/" + fileName;
                                propertyImage.description = "Proba";
                                //unitOfWork.PropertyImageRepository.Insert(propertyImage);

                                property.propertyImages.Add(propertyImage);
                                count++;
                            }
                        }

                    }

                    if (count == 0)
                    {


                        PropertyImage propertyImage = new PropertyImage();
                        propertyImage.url = "~/Images/default.jpg";
                        propertyImage.description = "Proba";
                        //unitOfWork.PropertyImageRepository.Insert(propertyImage);

                        property.propertyImages.Add(propertyImage);
                    }


                    unitOfWork.Save();
                }
                catch(Exception e)
                {
                    return View(property);
                }

                return View("Details", property);
              }
              return View(property);
          }

            // GET: Properties/Delete/5
            [Authorize(Roles = "Admin, Agent")]
            public ActionResult Delete(long? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Property property = unitOfWork.PropertyRepository.GetById(id);
                if (property == null)
                {
                    return HttpNotFound();
                }
                return View(property);
            }

            // POST: Properties/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = "Admin, Agent")]
            public ActionResult DeleteConfirmed(long id)
            {
                Property property = unitOfWork.PropertyRepository.GetById(id);

            Sale sale = unitOfWork.SalesRepository.GetSaleByPropertyId(id);
            if(sale != null)
            {
                unitOfWork.SalesRepository.Delete(sale);
            }
            Rent rent = unitOfWork.RentRepository.GetRentByPropertyId(id);
            if (rent != null)
            {
                unitOfWork.RentRepository.Delete(rent);
            }

            IEnumerable<PropertyImage> images = unitOfWork.PropertyImageRepository.GetImagesByPropertyId(id);
            if (images.Count() > 0)
            {
                foreach(PropertyImage image in images)
                {
                    unitOfWork.PropertyImageRepository.Delete(image);
                }
            }

            unitOfWork.PropertyRepository.Delete(property);
            unitOfWork.Save();
            return RedirectToAction("Index");
            } 

        protected override void Dispose(bool disposing)
           {
               if (disposing)
               {
                unitOfWork.Dispose();
                }
               base.Dispose(disposing);
          }

        /* /*  protected override void Dispose(bool disposing)
         {
             unitOfWork.Dispose();
             base.Dispose(disposing);
         } */
    }
}
