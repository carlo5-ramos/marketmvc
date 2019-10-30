using Market.Models;
using Market.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Market.Controllers
{
    public class OrdersController : Controller
    {
        MarketContext db = new MarketContext();
        // GET: Orders
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            Session["OrderView"] = orderView;

            var list = db.Customers.ToList();          
            list.Add(new Customer {CustomerID = 0, FirstName = "[Seleccione un cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");

            return View(orderView);
        }

        // Post: Orders
        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un cliente...]" });
            list = list.OrderBy(c => c.FullName).ToList();           
            ViewBag.CustomerID = new SelectList(list, "CustomerID", "FullName");
            return View(orderView);
        }

        public ActionResult AddProduct()
        {
            var list = db.Products.ToList();
            list.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...]" });
            list = list.OrderBy(p => p.Description).ToList();                
            ViewBag.ProductID = new SelectList(list, "ProductID", "Description");
            return View();

        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;
            var productID = int.Parse(Request["ProductID"]);
            if (productID == 0)
            {
                var list = db.Products.ToList();
                list.Add(new ProductOrder { ProductID = 0, Description = "[Seleccione un producto...]" });
                list = list.OrderBy(c => c.Description).ToList();                           
                ViewBag.ProductID = new SelectList(list, "ProductID", "Description");
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }

            var product = db.Products.Find(productID);
            if (product == null)
            {
                var list = db.Products.ToList();
                list.Add(new ProductOrder { ProductID = 0, Description = "Seleccione un producto..." });
                list = list.OrderBy(c => c.Description).ToList();
                ViewBag.ProductID = new SelectList(list, "ProductID", "Description");
                ViewBag.Error = "Producto no existe";
                return View(productOrder);
            }

            productOrder = orderView.Products.Find(p => p.ProductID == productID);
            if (productOrder == null)
            {
                productOrder = new ProductOrder
                {
                    Description = product.Description,
                    Price = product.Price,
                    ProductID = product.ProductID,
                    Quantity = float.Parse(Request["Quantity"]),
                };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }                       
            

            var listC = db.Customers.ToList();
            listC.Add(new Customer { CustomerID = 0, FirstName = "[Seleccione un cliente...]" });
            listC = listC.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerID = new SelectList(listC, "CustomerID", "FullName");

            return View("NewOrder", orderView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}