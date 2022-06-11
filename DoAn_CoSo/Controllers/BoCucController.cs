using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CoSo.Controllers
{
    public class BoCucController : Controller
    {
        // GET: BoCuc
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}