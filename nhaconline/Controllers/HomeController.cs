using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataIO;
using System.Web.Mvc;
using DatabaseProvider;
using System.IO;

namespace nhaconline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBIO db = new DBIO();
            List<nhac> list = db.GetList_Nhac();
            ViewBag.ThucUongList = list;
            List<chude> list2 = db.GetList_Chude();
            ViewBag.cdList = list2;
            return View(list);
        }
        public ActionResult ChuDe()
        {
            DBIO db = new DBIO();
            List<theloai> list2 = db.GetList_TheLoai();
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult XemChuDe(string id)
        {
            DBIO db = new DBIO();
            List<nhac> list2 = db.GetNhacs_TL(id);
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult BXH()
        {
            DBIO db = new DBIO();
            List<nhac> list2 = db.GetNhacs_BXH();
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult PlayNhac(string id)
        {
            DBIO db = new DBIO();
            List<nhac> list2 = db.GetNhacs_Play(id);
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult PlayNhacAlbum(string id)
        {
            DBIO db = new DBIO();
            List<nhac> list2 = db.GetNhacs_Album(id);
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult Album()
        {
            DBIO db = new DBIO();
            List<chude> list2 = db.GetList_Chude();
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult Casi()
        {
            DBIO db = new DBIO();
            List<casi> list2 = db.GetList_Casi();
            ViewBag.cdList = list2;
            return View(list2);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult AddCaSi()
        {
            ViewBag.Message = "Thêm Ca Sĩ.";
            DBIO db = new DBIO();
            List<casi> list3 = db.GetList_Casi();
            ViewBag.ThucUongList = list3;
            return View(list3);
        }
         public ActionResult Login()
         {
             return View();
         }
        public ActionResult userPanel()
        {
            int a = Convert.ToInt32(Session["Type"].ToString());
            if (a < 1) { return RedirectToAction("~/Admin/index"); }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult KtLogin(FormCollection data)
        {
            string ten = data["usname"];
            string mk = data["pword"];
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(ten))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "Không thể bỏ trống dữ liệu!"
                };
            }
            else
            {
                DBIO db = new DBIO();
                taikhoan b = new taikhoan();
                b = db.GetObject_User(ten, mk);
                if (b != null) { 
                    Session["UserName"] = b.UserName;
                    Session["PassWord"] = b.PassWord;
                    Session["DisplayName"] = b.DisplayName;
                    Session["DiaChi"] = b.DiaChi;
                    Session["SDT"] = b.SDT;
                    Session["Type"] = b.Type;
                    js.Data = new
                    {
                        status = "OK",
                        message = "Đăng nhập thành công!"
                    };
                }
                else
                {
                    js.Data = new
                    {
                        status = "ER",
                        message = "Tài khoản hoặc mật khẩu không đúng"
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        /* [HttpPost]
         public JsonResult KtLogin(FormCollection data)
         {
             string ten = data["usname"];
             string mk = data["pword"];
             JsonResult js = new JsonResult();
             if (String.IsNullOrEmpty(ten))
             {
                 js.Data = new
                 {
                     status = "ER",
                     message = "Không thể bỏ trống dữ liệu!"
                 };
             }
             else
             {
                 DBIO db = new DBIO();
                 taikhoan b = new taikhoan();
                 //dm.idDanhMuc = Guid.NewGuid().ToString();
                 b=db.GetObject_User(ten, mk);
                 Session["UserName"] = b.UserName;
                 Session["PassWord"] = b.PassWord;
                 Session["DisplayName"] = b.DisplayName;
                 Session["DiaChi"] = b.DiaChi;
                 Session["SDT"] = b.SDT;
                 Session["Type"] = b.Type;
                 js.Data = new
                 {
                     status = "OK",
                     message = "Đăng nhập thành công!"
                 };
             }
             return Json(js, JsonRequestBehavior.AllowGet);
         }
         public ActionResult AddDanhMuc()
         {
             ViewBag.Message = "Your application description page.";
             DBIO db = new DBIO();
             List<thucuong> list3 = db.GetList_ThucUong();
             ViewBag.ThucUongList = list3;
             List<danhmuc> list2 = db.GetList_DanhMuc();
             ViewBag.DanhMucList = list2;
             List<ban> list = db.GetList_Ban();
             return View(list2);
         }
         public ActionResult XoaDanhMuc(string id)
         {
             DBIO db = new DBIO();
             db.Xoa_danhMuc(id);
             return RedirectToAction("AddDanhMuc");
         }
         public ActionResult AddBan()
         {
             ViewBag.Message = "Your application description page.";
             DBIO db = new DBIO();
             List<thucuong> list3 = db.GetList_ThucUong();
             ViewBag.ThucUongList = list3;
             List<danhmuc> list2 = db.GetList_DanhMuc();
             ViewBag.DanhMucList = list2;
             List<ban> list = db.GetList_Ban();
             return View(list);
         }
         public ActionResult AddThucUong()
         {
             ViewBag.Message = "Your application description page.";
             DBIO db = new DBIO();
             List<danhmuc> list2 = db.GetList_DanhMuc();
             ViewBag.DanhMucList = list2;
             List<thucuong> list = db.GetList_ThucUong();
             ViewBag.ThucUongList = list;
             return View(list);
         }
         public ActionResult XoaThucUong(string id)
         {
             DBIO db = new DBIO();
             db.Xoa_thucUong(id);
             return RedirectToAction("AddThucUong");
         }
         [HttpPost]
         public JsonResult SaveDM(FormCollection data)
         {
             string tendm = data["txtdm"];
             JsonResult js = new JsonResult();
             if (String.IsNullOrEmpty(tendm))
             {
                 js.Data = new
                 {
                     status = "ER",
                     message = "Không thể bỏ trống dữ liệu!"
                 };
             }
             else
             {
                 DBIO db = new DBIO();
                 danhmuc dm = new danhmuc();
                 //dm.idDanhMuc = Guid.NewGuid().ToString();
                 dm.nameDanhMuc = tendm;
                 dm.idDanhMuc = Guid.NewGuid().ToString();
                 db.addObject(dm);
                 db.Save();
                 js.Data = new
                 {
                     status = "OK",
                     message = "Danh mục đã được thêm thành công!"
                 };
             }
             return Json(js, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public JsonResult SaveBan(FormCollection data)
         {
             string ten = data["txtBan"];
             JsonResult js = new JsonResult();
             if (String.IsNullOrEmpty(ten))
             {
                 js.Data = new
                 {
                     status = "ER",
                     message = "Không thể bỏ trống dữ liệu!"
                 };
             }
             else
             {
                 DBIO db = new DBIO();
                 ban b = new ban();
                 //dm.idDanhMuc = Guid.NewGuid().ToString();
                 b.nameBan = ten;
                 b.idBan = Guid.NewGuid().ToString();
                 b.status = 1;
                 db.addObject(b);
                 db.Save();
                 js.Data = new
                 {
                     status = "OK",
                     message = "Bàn đã được thêm thành công!"
                 };
             }
             return Json(js, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         public JsonResult SaveThucUong(HttpPostedFileBase txtHinh, string txtTU, string txtGia, string txtDM)
         {
                 string ten = txtTU;
                 string dm = txtDM;
                 int gia = int.Parse(txtGia);
                 string imagePath = "";

                 if (txtHinh != null && txtHinh.ContentLength > 0)
                 {
                     string uploadPath = Server.MapPath("~/Content/hinh/");
                     if (!Directory.Exists(uploadPath))
                     {
                         Directory.CreateDirectory(uploadPath);
                     }

                     string fileName = Guid.NewGuid().ToString() + Path.GetExtension(txtHinh.FileName);
                     string filePath = Path.Combine(uploadPath, fileName);
                     txtHinh.SaveAs(filePath);
                     imagePath =  fileName;
                 }

                 // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
                 JsonResult js = new JsonResult();
                 if (String.IsNullOrEmpty(ten))
                 {
                     js.Data = new
                     {
                         status = "ER",
                         message = "Không thể bỏ trống dữ liệu!"
                     };
                 }
                 else
                 {
                     DBIO db = new DBIO();
                     thucuong tu = new thucuong();
                     //dm.idDanhMuc = Guid.NewGuid().ToString();
                     tu.nameThucUong = ten;
                     tu.idThucUong = Guid.NewGuid().ToString();
                     tu.gia = gia;
                     tu.hinh = imagePath;
                     db.addObject(tu);
                     db.Save();
                 js.Data = new
                 {
                     status = "OK",
                     message = "Thức uóng đã được thêm thành công!",
                     hinh = imagePath
                     };
                 }
             return Json(js, JsonRequestBehavior.AllowGet);
         }
         public JsonResult SaveThucUong(FormCollection data)
         {
             string ten = data["txtTU"];
             string dm = data["txtDM"];
             string hinh = data["txtHinh"];
             string gia = data["txtGia"];

             JsonResult js = new JsonResult();
             if (String.IsNullOrEmpty(ten))
             {
                 js.Data = new
                 {
                     status = "ER",
                     message = "Không thể bỏ trống dữ liệu!"
                 };
             }
             else
             {
                 DBIO db = new DBIO();
                 ban b = new ban();
                 //dm.idDanhMuc = Guid.NewGuid().ToString();
                 b.nameBan = ten;
                 b.idBan = Guid.NewGuid().ToString();
                 b.status = 1;
                 db.addObject(b);
                 db.Save();
                 js.Data = new
                 {
                     status = "OK",
                     message = "Bàn đã được thêm thành công!"
                 };
             }
             return Json(js, JsonRequestBehavior.AllowGet);
         }
         public ActionResult About()
         {
             ViewBag.Message = "Your application description page.";

             return View();
         }

         public ActionResult Contact()
         {
             ViewBag.Message = "Your contact page.";

             return View();
         }
        */
    }
}