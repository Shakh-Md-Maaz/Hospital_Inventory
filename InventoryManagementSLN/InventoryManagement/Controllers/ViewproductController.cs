using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class ViewproductController : Controller
    {
        //GET: Product
        MyContextDb db = new MyContextDb();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ProductList()
        {
            var proList = db.Products.Where(p => p.IsDeleted == false).Select(p => new ProductViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price,
                Quantity = p.Quantity,
                ProductExpDate = p.ProductExpDate,
                CompanyName = p.Supplier.CompanyName
            }).ToList();
            return Json(proList, JsonRequestBehavior.AllowGet);
        }
    }
}