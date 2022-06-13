using KiemTra_TranDanTruong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_TranDanTruong.Controllers
{
    public class Nguoidung1Controller : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: Nguoidung1
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FromCollection collection, Sinhvien sv)

        {
            var hoten = collection["hoten"];
            var tendangnhap = collection["tendangnnhap"];
            var matkhau = collection["matkhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);

            if (String.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["MhapMKXN"] = "Phai nhap mat khau xac nhan!";

            }
            else
            {
                if(!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mat khau va mat khau vac nhan phai giong nhau";
                }
                else
                {
                    sv.hoten = hoten;
                    sv.tendangnhap = tendangnhap;
                    sv.matkhau = matkhau;
                    sv.email = email;
                    sv.diachi = diachi;
                    sv.dienthoai = dienthoai;
                    sv.ngaysinh = DateTime.Parse(ngaysinh);

                    data.SinhViens.InsertAllOnSubmit(sv);
                    data.SubmitChanges();
                    return RedirectToAction("Dangnhap");
                }
            }
            return this.DangKy();

        }
    }
}