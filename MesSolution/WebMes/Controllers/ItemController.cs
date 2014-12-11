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

namespace WebMes.Controllers
{
    public class ItemController : Controller
    {
        private MesContext db = new MesContext();

        // GET: /Item/
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: /Item/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: /Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Item/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ITEMCODE,ITEMNAME,ITEMDESC,ITEMUOM,ITEMVER,ITEMTYPE,ITEMCONTROL,ITEMUSER,ITEMDATE,MUSER,MDATE,MTIME,EATTRIBUTE1,ITEMCONFIG,ITEMCARTONQTY,ITEMBURNINQTY,ELECTRICCURRENTMINVALUE,ELECTRICCURRENTMAXVALUE,SHIPBOXCAPACITY,PKRULECODE,ORGID,CHKITEMOP,LOTSIZE,PRODUCTCODE,NEEDCHKCARTON,NEEDCHKACCESSORY,CKDPREFIX,CARTONHEIGHT,ALLOWHEIGHT,PRINTLABEL,IsDeleted,AddDate,Timestamp")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: /Item/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Item/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ITEMCODE,ITEMNAME,ITEMDESC,ITEMUOM,ITEMVER,ITEMTYPE,ITEMCONTROL,ITEMUSER,ITEMDATE,MUSER,MDATE,MTIME,EATTRIBUTE1,ITEMCONFIG,ITEMCARTONQTY,ITEMBURNINQTY,ELECTRICCURRENTMINVALUE,ELECTRICCURRENTMAXVALUE,SHIPBOXCAPACITY,PKRULECODE,ORGID,CHKITEMOP,LOTSIZE,PRODUCTCODE,NEEDCHKCARTON,NEEDCHKACCESSORY,CKDPREFIX,CARTONHEIGHT,ALLOWHEIGHT,PRINTLABEL,IsDeleted,AddDate,Timestamp")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: /Item/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: /Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
