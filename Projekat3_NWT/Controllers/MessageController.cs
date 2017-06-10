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
    
    public class MessageController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Message
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Index(int? page)
        {

            IEnumerable<Message> messages = unitOfWork.MessageRepository.Find(m => m.Answered == false);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(messages.OrderByDescending(m => m.DateSent).ToPagedList(pageNumber, pageSize));
        }

        // GET: Message/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(Message message)
        {
            if (ModelState.IsValid)
            {               
                try
                {
                    message.DateSent = DateTime.Now;
                    message.Answered = false;
                    unitOfWork.MessageRepository.Insert(message);
                    unitOfWork.Save();
                }
                catch
                {
                    return Json(new { success = false, message = "Error. Fill all fields and try again." });
                }
                return Json(new { success = true, message = "Success. We will review your message and get back to you shortly." });
            }

            return Json(new { success = false, message = "Error. Fill all fields and try again." });
        }

        // GET: Message/Edit/5
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = unitOfWork.MessageRepository.GetById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            message.Answered = true;
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Agent")]
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(Message message)
        {
            if (ModelState.IsValid)
            {
                message.DateSent = DateTime.Now;
                unitOfWork.MessageRepository.Update(message);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Properties/Delete/5
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = unitOfWork.MessageRepository.GetById(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Agent")]
        public ActionResult DeleteConfirmed(long id)
        {
            Message message = unitOfWork.MessageRepository.GetById(id);
            unitOfWork.MessageRepository.Delete(message);
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
