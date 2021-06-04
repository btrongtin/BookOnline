using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        private List<SACH> LaySachBanNhieu(int count)
        {
            return data.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }

        // GET: SachOnline
        public ActionResult Index()
        {
            //Lay 6 quyen sach moi
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }

        public ActionResult NavPartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult SliderPartial()
        {
            return PartialView();
        }

        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in data.CHUDEs select cd;
            return PartialView(listChuDe);
        }

        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.NHAXUATBANs select cd;
            return PartialView(listNhaXuatBan);
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LaySachBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.SACHes where s.MaSach == id select s;
            return View(sach.Single());
        }

        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB== id select s;
            return View(sach);
        }
    }
}