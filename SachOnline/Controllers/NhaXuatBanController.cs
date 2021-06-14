using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class NhaXuatBanController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        // GET: NhaXuatBan
        public ActionResult Index()
        {
            return View(from nxb in data.NHAXUATBANs select nxb);
        }

        //Cach 2
        public ActionResult Details()
        {
            int manxb = int.Parse(Request.QueryString["id"]);
            //int manxb = int.Parse(Request["id"]);
            var result = data.NHAXUATBANs.Where(nxb => nxb.MaNXB == manxb).SingleOrDefault();
            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            NHAXUATBAN nxb = data.NHAXUATBANs.Where(n => n.MaNXB == id).SingleOrDefault();
            return View(nxb);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NHAXUATBAN nxb)
        {
            if (ModelState.IsValid)
            {
                nxb.TenNXB = Request.Form["TenNXB"];
                nxb.DiaChi = Request.Form["DiaChi"];
                nxb.DienThoai= Request.Form["DienThoai"];
                UpdateModel(nxb);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
    }
}