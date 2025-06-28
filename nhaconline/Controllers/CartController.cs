using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataIO;
using DatabaseProvider;

namespace nhaconline.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartSession";
        /*
        // Lấy giỏ hàng từ Session
        private List<CartItem> GetCart()
        {
            var cart = Session[CartSessionKey] as List<CartItem>;
            if (cart == null)
            {
                cart = new List<CartItem>();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }

        // Hiển thị giỏ hàng
        public ActionResult Index()
        {
            DBIO db = new DBIO();
            List<thucuong> list = db.GetList_ThucUong();
            ViewBag.ThucUongList = list;
            List<danhmuc> list2 = db.GetList_DanhMuc();
            ViewBag.DanhMucList = list2;
            return View(GetCart());
        }

        // Thêm sản phẩm vào giỏ
        public JsonResult AddToCart(string productId, string productName, decimal price,string hinh)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { ProductId = productId, ProductName = productName, Price = price, Quantity = 1, Hinh = hinh });
            }

            return Json(new { success = true, totalItems = cart.Sum(x => x.Quantity) }, JsonRequestBehavior.AllowGet);
        }

        // Xóa sản phẩm khỏi giỏ
        public JsonResult RemoveFromCart(string productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        // Cập nhật số lượng sản phẩm
        public JsonResult UpdateCart(string productId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null && quantity > 0)
            {
                item.Quantity = quantity;
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult BuyCart()
        {
            var cart = GetCart();
            if(cart.Sum(x => x.Quantity) > 0)
            {
                DBIO db = new DBIO();
                donhang b = new donhang();
                //dm.idDanhMuc = Guid.NewGuid().ToString();
                
                b.idBill = Guid.NewGuid().ToString();
                b.idBan = "0";
                b.status = 0;
                DateTime now = DateTime.Now;
                b.DateCheckIn = now;
                b.UserName = Session["UserName"].ToString();
                db.addObject(b);
                db.Save();
                foreach (CartItem item in cart)
                {
                    chitietdonhang ct = new chitietdonhang();
                    //dm.idDanhMuc = Guid.NewGuid().ToString();

                    ct.id = Guid.NewGuid().ToString();
                    ct.idBill = b.idBill;
                    ct.idThucUong = item.ProductId;
                    ct.SoLuong = item.Quantity;
                    
                    db.addObject(ct);
                    db.Save();
                }
            }
            
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        // Xóa toàn bộ giỏ hàng
        public JsonResult ClearCart()
        {
            Session[CartSessionKey] = new List<CartItem>();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        */
    }
}