using InventoryManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        //GET: Product
        MyContextDb db = new MyContextDb();
        public ActionResult Index()
        {
            List<tSupplier> supList = db.Suppliers.ToList();
            ViewBag.ListOfSupplier = new SelectList(supList, "tSupplierID", "CompanyName");
            return View();
        }
        public JsonResult GetProductList()
        {
            System.Threading.Thread.Sleep(3000);
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


        public PartialViewResult GetDetailsProductRecord(int ProductID)
        {
            Product obj = db.Products.SingleOrDefault(p => p.IsDeleted == false && p.ProductID == ProductID);
            ProductViewModel productView = new ProductViewModel();
            productView.ProductID = obj.ProductID;
            productView.ProductName = obj.ProductName;
            productView.Price = obj.Price;
            productView.Quantity = obj.Quantity;
            productView.ProductExpDate = obj.ProductExpDate;
            productView.CompanyName = obj.Supplier.CompanyName;
            return PartialView("_ProductDetails", productView);
        }
        public JsonResult SaveDataInDatabase(ProductViewModel vObj)
        {
            var result = false;
            try
            {
                if (vObj.ProductID > 0)
                {
                    Product upObj = db.Products.SingleOrDefault(p => p.IsDeleted == false && p.ProductID == vObj.ProductID);
                    upObj.ProductName = vObj.ProductName;
                    upObj.Price = vObj.Price;
                    upObj.Quantity = vObj.Quantity;
                    upObj.ProductExpDate = vObj.ProductExpDate;
                    //upObj.CompanyID = vObj.CompanyID;
                    db.SaveChanges();
                    result = true;

                }
                else
                {
                    Product obj = new Product();
                    obj.ProductName = vObj.ProductName;
                    obj.Price = vObj.Price;
                    obj.Quantity = vObj.Quantity;
                    obj.ProductExpDate = vObj.ProductExpDate;
                    obj.IsDeleted = false;
                    obj.tSupplierID = vObj.tSupplierID;
                    db.Products.Add(obj);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducrById(int productID)
        {
            Product obj = db.Products.Where(p => p.IsDeleted == false && p.ProductID == productID).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteProductRecord(int productID)
        {
            var result = false;
            Product deobj = db.Products.SingleOrDefault(p => p.IsDeleted == false && p.ProductID == productID);
            if (deobj != null)
            {
                deobj.IsDeleted = true;
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}