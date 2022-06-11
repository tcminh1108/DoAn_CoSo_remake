using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_CoSo.Models;

namespace DoAn_CoSo.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        dbQLNongSanDataContext data = new dbQLNongSanDataContext();
        private List<SanPham> LaySPMoi(int soluong)
        {
            //Sắp xếp sản phẩm giảm dần theo ngày đăng bán
            return data.SanPhams.OrderByDescending(sp => sp.Ngaydangban).Take(soluong).ToList();
        }
        public ActionResult Index()
        {
            //lấy 12 sản phẩm mới nhất
            var SPMoi = LaySPMoi(12);
            return View(SPMoi);
        }
        public ActionResult DangXuat()
        {
            Session["hoten_kh"] = null;
            var SPMoi = LaySPMoi(12);
            return View(SPMoi);
        }
    }
}