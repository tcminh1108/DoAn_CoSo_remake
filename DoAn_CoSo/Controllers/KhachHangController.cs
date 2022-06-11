using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_CoSo.Models;
namespace DoAn_CoSo.Controllers
{
    public class KhachHangController : Controller
    {
        dbQLNongSanDataContext data = new dbQLNongSanDataContext();
        // GET: KhachHang
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var taikhoan = collection["taikhoan"];
            var matkhau = collection["matkhau"];
            if (string.IsNullOrEmpty(taikhoan))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else
            {
                var kh = data.KhachHangs.SingleOrDefault(n => n.Taikhoan_KH == taikhoan && n.Matkhau_KH == matkhau);
                if (kh != null)
                {
                    string hoten = kh.Hoten_KH;
                    Session["hoten_kh"] = hoten;
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                    ViewBag.Thongbao = "Tài khoản hoặc mật khẩu không hợp lệ!";
            }
            return this.DangNhap();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["taikhoan"];
            var taikhoan = collection["taikhoan"];
            var matkhau = collection["matkhau"];
            var nhaplaimatkhau = collection["nhaplaimatkhau"];
            var gmail = collection["gmail"];
            var xacthucgmail = false;
            var anhdaidien = "";
            var diachi = "";
            var dienthoai = "";
            if (string.IsNullOrEmpty(taikhoan))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else if (string.IsNullOrEmpty(gmail))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else if (string.IsNullOrEmpty(matkhau))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else if (string.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewBag.Thongbao = "Vui lòng nhập đủ thông tin!";
            }
            else
            {
                kh.Hoten_KH = hoten;
                kh.Taikhoan_KH = taikhoan;
                kh.Matkhau_KH = matkhau;
                kh.Gmail_KH = gmail;
                kh.Xacthucgmail = xacthucgmail;
                kh.Anhdaidien_KH = anhdaidien;
                kh.Diachi_KH = diachi;
                kh.Dienthoai_KH = dienthoai;
                data.KhachHangs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("DangNhap", "KhachHang");
            }
            return this.DangKy();
        }


    }
}