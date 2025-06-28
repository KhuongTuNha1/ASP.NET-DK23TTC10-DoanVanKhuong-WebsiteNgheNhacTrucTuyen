using DatabaseProvider;
using DataIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nhaconline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            DBIO db = new DBIO();
            List<nhac> list = db.GetList_Nhac();
            ViewBag.ThucUongList = list;
            List<casi> casi = db.GetList_Casi();
            ViewBag.casi = casi;
            List<theloai> theloai = db.GetList_TheLoai();
            ViewBag.theloai = theloai;
            List<chude> cd = db.GetList_Chude();
            ViewBag.cd = cd;
            return View(list);
        }
        public ActionResult ThemNhac()
        {
            DBIO db = new DBIO();
            List<nhac> list = db.GetList_Nhac();
            ViewBag.ThucUongList = list;
            List<casi> casi = db.GetList_Casi();
            ViewBag.casi = casi;
            List<theloai> theloai = db.GetList_TheLoai();
            ViewBag.theloai = theloai;
            List<chude> cd = db.GetList_Chude();
            ViewBag.cd = cd;
            return View(list);
        }
        public ActionResult ThemTaiKhoan()
        {
            DBIO db = new DBIO();
            List<taikhoan> list = db.GetList_User();
            return View(list);
        }
        public ActionResult ThemCaSi()
        {
            DBIO db = new DBIO();
            List<casi> casi = db.GetList_Casi();
            ViewBag.casi = casi;
            return View(casi);
        }
        public ActionResult ThemCD()
        {
            DBIO db = new DBIO();
            
            List<casi> casi = db.GetList_Casi();
            ViewBag.casi = casi;
            List<theloai> theloai = db.GetList_TheLoai();
            ViewBag.theloai = theloai;
            List<chude> cd = db.GetList_Chude();
            ViewBag.cd = cd;
            return View(cd);
        }
        public ActionResult ThemTheLoai()
        {
            DBIO db = new DBIO();

            List<theloai> theloai = db.GetList_TheLoai();
            ViewBag.theloai = theloai;
            return View(theloai);
        }
        public ActionResult SuaTheLoai(string id)
        {
            DBIO db = new DBIO();
            List<theloai> theloai = db.GetList_TheLoai(id);
            return View(theloai);
        }
        [HttpPost]
        public JsonResult SaveNhac(string TenBH, string CaSi, string theloai,string cd, HttpPostedFileBase hinh, HttpPostedFileBase _file)
        {
            
            string imagePathHinh = "";
            string imagePathFile = "";
            if (hinh != null && hinh.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/Content/hinh/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hinh.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                hinh.SaveAs(filePath);
                imagePathHinh = fileName;
            }
            if (_file != null && _file.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/Content/mp3/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(_file.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                hinh.SaveAs(filePath);
                imagePathFile = fileName;
            }
            // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TenBH))
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
                nhac nh = new nhac();
                //dm.idDanhMuc = Guid.NewGuid().ToString();
                nh.TenBH = TenBH;
                nh.MaBH = Guid.NewGuid().ToString();
                nh.CaSi = CaSi;
                nh.TL = theloai;
                nh.Image = imagePathHinh;
                nh.FileLuu = imagePathFile;
                db.addObject(nh);
                db.Save();
                js.Data = new
                {
                    status = "OK",
                    message = "Thức uóng đã được thêm thành công!",
                    hinh = imagePathHinh
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveTL(string TenTL, HttpPostedFileBase hinh)
        {

            string imagePathHinh = "";

            if (hinh != null && hinh.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/Content/hinh/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hinh.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                hinh.SaveAs(filePath);
                imagePathHinh = fileName;
            }
           
            // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TenTL))
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
                theloai tl = new theloai();
                tl.TenTl = TenTL;
                tl.MaTl = Guid.NewGuid().ToString();
                tl.Hinh = imagePathHinh;
                db.addObject(tl);
                db.Save();
                js.Data = new
                {
                    status = "OK",
                    message = "Thức uóng đã được thêm thành công!",
                    hinh = imagePathHinh
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveSuaTL(string TenTL, HttpPostedFileBase hinh, string hinh2, string MaTL)
        {

            string imagePathHinh = "";
            if (hinh2 == "") { }
            else { 
                if (hinh != null && hinh.ContentLength > 0)
                {
                    string uploadPath = Server.MapPath("~/Content/hinh/");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(hinh.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);
                    hinh.SaveAs(filePath);
                    imagePathHinh = fileName;
                }
            }
            // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TenTL))
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
                theloai tl = db.GetObject_TheLoai(MaTL);
                if (tl == null)
                {
                    js.Data = new
                    {
                        status = "ERR",
                        message = "Tìm không thấy Thể loại để sửa!",
                        hinh = imagePathHinh
                    };
                }
                else { 
                    tl.TenTl = TenTL;
                    if (hinh2 == "") { }
                    else
                        tl.Hinh = imagePathHinh;
                    db.Save();
                    js.Data = new
                    {
                        status = "OK",
                        message = "Thể loại đã được thêm thành công!",
                        hinh = imagePathHinh
                    };
                }
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCD(string TenCD, string TL, string CaSi, HttpPostedFileBase Picture)
        {

            string imagePathHinh = "";

            if (Picture != null && Picture.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/Content/hinh/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Picture.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                Picture.SaveAs(filePath);
                imagePathHinh = fileName;
            }

            // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TenCD))
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
                chude temp = new chude();
                temp.TenCD = TenCD;
                temp.MaCD = Guid.NewGuid().ToString();
                temp.CaSi = CaSi;
                temp.TL = TL;
                temp.Picture = imagePathHinh;
                db.addObject(temp);
                db.Save();
                js.Data = new
                {
                    status = "OK",
                    message = "Thức uóng đã được thêm thành công!",
                    hinh = imagePathHinh
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCaSi(string TenCs, string QuocGia, HttpPostedFileBase Image)
        {

            string imagePathHinh = "";

            if (Image != null && Image.ContentLength > 0)
            {
                string uploadPath = Server.MapPath("~/Content/hinh/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                string filePath = Path.Combine(uploadPath, fileName);
                Image.SaveAs(filePath);
                imagePathHinh = fileName;
            }

            // Giả sử bạn có một lớp Student và muốn lưu vào DB (Entity Framework)
            JsonResult js = new JsonResult();
            if (String.IsNullOrEmpty(TenCs))
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
                casi temp = new casi();
                temp.TenCs = TenCs;
                temp.MaCs = Guid.NewGuid().ToString();
                temp.QuocGia = QuocGia;
                temp.Picture = imagePathHinh;
                db.addObject(temp);
                db.Save();
                js.Data = new
                {
                    status = "OK",
                    message = "Thức uóng đã được thêm thành công!",
                    hinh = imagePathHinh
                };
            }
            return Json(js, JsonRequestBehavior.AllowGet);
        }
    }
}