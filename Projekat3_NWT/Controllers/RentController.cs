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
using PagedList;

namespace Projekat3_NWT.Controllers
{
    [Authorize(Roles = "Admin, Agent")]
    public class RentController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Rent
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            IEnumerable<Rent> rents = unitOfWork.RentRepository.GetAll();

            if (String.IsNullOrEmpty(sortOrder))
            {
                rents = rents.OrderByDescending(r => r.startDate);
                ViewBag.SortParm = "startdate_desc";
            }
            else
            {
                switch (sortOrder)
                {
                    case "startdate_asc":
                        rents = rents.OrderBy(r => r.startDate);
                        ViewBag.SortParm = "startdate_asc";
                        break;

                    case "enddate_desc":
                        rents = rents.OrderByDescending(r => r.endDate);
                        ViewBag.SortParm = "enddate_desc";
                        break;

                    case "enddate_asc":
                        rents = rents.OrderBy(r => r.endDate);
                        ViewBag.SortParm = "enddate_asc";
                        break;

                    case "fee_desc":
                        rents = rents.OrderByDescending(r => r.MonthlyFee);
                        ViewBag.SortParm = "fee_desc";
                        break;

                    case "fee_asc":
                        rents = rents.OrderBy(r => r.MonthlyFee);
                        ViewBag.SortParm = "fee_asc";
                        break;

                }
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(rents.ToPagedList(pageNumber, pageSize));
        }

        // GET: Rent/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = unitOfWork.RentRepository.GetById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rent/Create
        public ActionResult Create(long? PropertyId)
        {
            if (PropertyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CreateRentView createRentView = new CreateRentView();

            createRentView.Property = unitOfWork.PropertyRepository.GetById(PropertyId);

            createRentView.AgentsList = unitOfWork.ApplicationUserRepository.getAllAgents();
            createRentView.ClientsList = unitOfWork.ApplicationUserRepository.getAllClients();
            createRentView.startDate = DateTime.Now;
            createRentView.endDate = DateTime.Now;    
            

            createRentView.PropertyId = (long)PropertyId;

            return View(createRentView);
        }

        // POST: Rent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRentView createRentView, long PropertyId)
        {
            if (ModelState.IsValid)
            {
                // db.Rents.Add(rent);
                Rent rent = new Rent();
                rent.MonthlyFee = createRentView.MonthlyFee;
                rent.startDate = createRentView.startDate;
                rent.endDate = createRentView.endDate;
                rent.Agent = unitOfWork.ApplicationUserRepository.GetById(createRentView.AgentId);
                rent.client = unitOfWork.ApplicationUserRepository.GetById(createRentView.BuyerId);

                rent.Contract = new Contract();
                rent.Contract.content = createRentView.contract_content;
                rent.Contract.title = createRentView.contract_title;

                unitOfWork.ContractRepository.Insert(rent.Contract);

                rent.Property = unitOfWork.PropertyRepository.GetById(PropertyId);

                rent.Property.available = false;
                unitOfWork.PropertyRepository.Update(rent.Property);

                unitOfWork.RentRepository.Insert(rent);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }



            createRentView.Property = unitOfWork.PropertyRepository.GetById(PropertyId);

            createRentView.AgentsList = unitOfWork.ApplicationUserRepository.getAllAgents();
            createRentView.ClientsList = unitOfWork.ApplicationUserRepository.getAllClients();
            createRentView.startDate = DateTime.Now;
            createRentView.endDate = DateTime.Now;


            createRentView.PropertyId = PropertyId;

            return View(createRentView);
        }

        // GET: Rent/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = unitOfWork.RentRepository.GetById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            CreateRentView createRentView = new CreateRentView();


            createRentView.Property = rent.Property;

            createRentView.AgentsList = unitOfWork.ApplicationUserRepository.getAllAgents();
            createRentView.ClientsList = unitOfWork.ApplicationUserRepository.getAllClients();
            createRentView.startDate = rent.startDate;
            createRentView.endDate = rent.endDate;


            createRentView.PropertyId = rent.Property.Id;

            createRentView.Contract = rent.Contract;
            createRentView.contract_content = rent.Contract.content;
            createRentView.contract_title = rent.Contract.title;

            createRentView.MonthlyFee = rent.MonthlyFee;
            createRentView.RentId = rent.Id;

            createRentView.AgentId = rent.Agent.Id;
            createRentView.BuyerId = rent.client.Id;

            return View(createRentView);
        }

        // POST: Rent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateRentView createRentView)
        {
            if (ModelState.IsValid)
            {
                Rent rent = unitOfWork.RentRepository.GetById(createRentView.RentId);

                rent.endDate = createRentView.endDate;
                rent.startDate = createRentView.startDate;
                rent.MonthlyFee = createRentView.MonthlyFee;
                rent.Contract.content = createRentView.contract_content;
                rent.Contract.title = createRentView.contract_title;
                rent.Agent = unitOfWork.ApplicationUserRepository.GetById(createRentView.AgentId);
                rent.client = unitOfWork.ApplicationUserRepository.GetById(createRentView.BuyerId);
                unitOfWork.ContractRepository.Update(rent.Contract);
                unitOfWork.RentRepository.Update(rent);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            
            return View(createRentView);
        }

        // GET: Rent/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = unitOfWork.RentRepository.GetById(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Rent rent = unitOfWork.RentRepository.GetById(id);

            rent.Property.available = true;
            unitOfWork.PropertyRepository.Update(rent.Property);

            unitOfWork.ContractRepository.Delete(rent.Contract);
            unitOfWork.RentRepository.Delete(rent);

           

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
    }
}
