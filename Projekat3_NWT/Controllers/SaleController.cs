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
using PagedList;

namespace Projekat3_NWT.Controllers
{
    [Authorize(Roles = "Admin, Agent")]
    public class SaleController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Sale
        public ActionResult Index(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            IEnumerable<Sale> sales = unitOfWork.SalesRepository.GetAll();

            if (String.IsNullOrEmpty(sortOrder))
            {
                sales = sales.OrderByDescending(s => s.DateOfSale);
                ViewBag.SortParm = "date_desc";
            }
            else
            {
                switch (sortOrder)
                {
                    case "date_asc":
                        sales = sales.OrderBy(s => s.DateOfSale);
                        ViewBag.SortParm = "date_asc";
                        break;

                    case "price_desc":
                        sales = sales.OrderByDescending(s => s.Price);
                        ViewBag.SortParm = "availablefor_desc";
                        break;

                    case "price_asc":
                        sales = sales.OrderBy(s => s.Price);
                        ViewBag.SortParm = "availablefor_desc";
                        break;

                }
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sales.ToPagedList(pageNumber, pageSize));
        }

        // GET: Sale/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = unitOfWork.SalesRepository.GetById(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sale/Create
        [Authorize(Roles ="Admin, Agent")]
        public ActionResult Create(long PropertyId)
        {
            CreateSaleView createSaleView = new CreateSaleView();

            createSaleView.Property = unitOfWork.PropertyRepository.GetById(PropertyId);

            createSaleView.AgentsList = unitOfWork.ApplicationUserRepository.getAllAgents();
            createSaleView.ClientsList = unitOfWork.ApplicationUserRepository.getAllClients();
            createSaleView.DateOfSale = DateTime.Now;

            createSaleView.PropertyId = PropertyId;

            return View(createSaleView);
        }

        // POST: Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Create(CreateSaleView createSaleView, long PropertyId)
        {
            if (ModelState.IsValid)
            {
                Sale sale = new Sale();
                sale.Price = createSaleView.Price;
                sale.DateOfSale = createSaleView.DateOfSale;
                sale.Agent = unitOfWork.ApplicationUserRepository.GetById(createSaleView.AgentId);
                sale.Buyer = unitOfWork.ApplicationUserRepository.GetById(createSaleView.BuyerId);

                Contract contract = new Contract();
                contract.title = createSaleView.contract_title;
                contract.content = createSaleView.contract_content;
                unitOfWork.ContractRepository.Insert(contract);

                sale.Contract = contract;

                sale.Property = unitOfWork.PropertyRepository.GetById(PropertyId);

                sale.Property.available = false;
                unitOfWork.PropertyRepository.Update(sale.Property);

                unitOfWork.SalesRepository.Insert(sale);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            //return View(sale);
            return View();
            //return RedirectToAction("Index");
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(long? id)//SaleId
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = unitOfWork.SalesRepository.GetById(id);

            CreateSaleView createSaleView = new CreateSaleView(sale);

            createSaleView.AgentsList = unitOfWork.ApplicationUserRepository.getAllAgents();
            createSaleView.ClientsList = unitOfWork.ApplicationUserRepository.getAllClients();

            createSaleView.AgentId = sale.Agent.Id;
            createSaleView.BuyerId = sale.Buyer.Id;

            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(createSaleView);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateSaleView createSaleView)
        {
            if (ModelState.IsValid)
            {
                Sale sale = unitOfWork.SalesRepository.GetById(createSaleView.SaleId);

                sale.Price = createSaleView.Price;
                sale.Contract.content = createSaleView.contract_content;
                sale.Contract.title = createSaleView.contract_title;

                sale.DateOfSale = createSaleView.DateOfSale;

                sale.Agent = unitOfWork.ApplicationUserRepository.GetById(createSaleView.AgentId);
                sale.Buyer = unitOfWork.ApplicationUserRepository.GetById(createSaleView.BuyerId);

                unitOfWork.ContractRepository.Update(sale.Contract);
                unitOfWork.SalesRepository.Update(sale);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(createSaleView);
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = unitOfWork.SalesRepository.GetById(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sale sale = unitOfWork.SalesRepository.GetById(id);
            unitOfWork.ContractRepository.Delete(sale.Contract);
            unitOfWork.SalesRepository.Delete(sale);

            sale.Property.available = true;
            unitOfWork.PropertyRepository.Update(sale.Property);

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
