using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Core.Db.Context;
using PagedList;

namespace WebMes.Controllers
{
    public class OpController : Controller
    {
        private MesContext db = new MesContext();

        // GET: /Op/
        public ActionResult Index(int page=1)
        {
            const int pageSize = 3;
            //List<User> users = (from u in db.Users
            //  orderby u.Id descending
            //  select u).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //return View(users);
            var iUsers = db.Ops.OrderBy(p => p.OPCODE).ToPagedList(page, pageSize);
            return View(iUsers);
           // return View(db.Ops.ToList());
        }

        // GET: /Op/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Op op = db.Ops.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return View(op);
        }

        // GET: /Op/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Op/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OPCODE,OPDESC,OPCOLLECTION,OPCONTROL,MUSER,MDATE,MTIME,EATTRIBUTE1,Timestamp,IsDeleted,AddDate")] Op op)
        {
            if (ModelState.IsValid)
            {
                db.Ops.Add(op);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(op);
        }

        // GET: /Op/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Op op = db.Ops.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return View(op);
        }

        // POST: /Op/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OPCODE,OPDESC,OPCOLLECTION,OPCONTROL,MUSER,MDATE,MTIME,EATTRIBUTE1,Timestamp,IsDeleted,AddDate")] Op op)
        {
            if (ModelState.IsValid)
            {
                Op op2=  db.Ops.Find(op.OPCODE);
                //op.Timestamp = op2.Timestamp;
                op2.Merge(op2,op);
                //db.Entry(op).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(op);
        }

        // GET: /Op/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Op op = db.Ops.Find(id);
            if (op == null)
            {
                return HttpNotFound();
            }
            return View(op);
        }

        // POST: /Op/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Op op = db.Ops.Find(id);
            db.Ops.Remove(op);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
