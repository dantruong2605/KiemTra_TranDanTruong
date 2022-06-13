using KiemTra_TranDanTruong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_TranDanTruong.Controllers
{
    public class SinhvienController : Controller
    {
        // GET: Sinhvien
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from tt in data.SinhViens select tt;
            return View(all_sinhvien);
        }

        public ActionResult Detail(string id)
        {
            var D_Sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_Sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var ten = collection["HoTen"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.HoTen = ten;
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_category = data.SinhViens.First(m => m.MaSV == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var SinhVien = data.SinhViens.First(m => m.MaSV == id);
            var E_HoTen = collection["tenloai"];
            SinhVien.MaSV = id;
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                SinhVien.HoTen = E_HoTen;
                UpdateModel(SinhVien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_Sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_Sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_Sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_Sinhvien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

    }
}