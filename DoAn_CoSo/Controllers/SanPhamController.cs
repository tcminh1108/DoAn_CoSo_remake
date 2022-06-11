using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_CoSo.Models;

namespace DoAn_CoSo.Controllers
{
    public class SanPhamController : Controller
    {
        dbQLNongSanDataContext data = new dbQLNongSanDataContext();
        // GET: SanPham
        public ActionResult Index()
        {
            var DanhSachSP = from sp in data.SanPhams select sp;
            return View(DanhSachSP);
        }
        public ActionResult LoaiSP()
        {
            var LoaiSP = from lsp in data.LoaiSanPhams select lsp;
            return PartialView(LoaiSP);
        }
        public ActionResult SPTheoLoai(int Ma_LSP)
        {
            var SPTheoLoai = from sp in data.SanPhams where sp.Ma_LSP == Ma_LSP select sp;
            return View(SPTheoLoai);
        }
        public ActionResult ChiTietSP(int Ma_SP)
        {
            
            var ChiTietSP = from sp in data.SanPhams where sp.Ma_SP == Ma_SP select sp;
            Session["Ma_LSP"] = data.SanPhams.FirstOrDefault().Ma_LSP; 
            return View(ChiTietSP);
        }
        public ActionResult SPLienQuan()
        {
            var Ma_LSP = (int)Session["Ma_LSP"];
            var SPLienQuan = data.SanPhams.OrderByDescending(sp => sp.Ngaydangban).Where(sp => sp.Ma_LSP == Ma_LSP).Take(8).ToList();
            return PartialView(SPLienQuan);
        }
    }
}