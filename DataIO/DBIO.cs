using DatabaseProvider;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIO
{
    public class DBIO
    {
        MyDB mydb = new MyDB();
        public void addObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }
        public List<taikhoan> GetList_User()
        {
            return mydb.taikhoans.ToList();
        }
        public List<theloai> GetList_TheLoai()
        {
            return mydb.theloais.ToList();
        }
        public List<theloai> GetList_TheLoai(string id)
        {
            string sql = "SELECT * FROM theloai WHERE MaTL='" + id + "'";
            return mydb.Database.SqlQuery<theloai>(sql).ToList();
        }
        public List<nhac> GetNhacs_TL(string tl)
        {
            string sql = "SELECT TOP(8) * FROM nhac WHERE MaTL='" + tl  + "'";
            return mydb.Database.SqlQuery<nhac>(sql).ToList();
        }
        public List<nhac> GetNhacs_Album(string cd)
        {
            string sql = "SELECT  * FROM nhac WHERE MaCD='" + cd + "'";
            return mydb.Database.SqlQuery<nhac>(sql).ToList();
        }
        public List<nhac> GetNhacs_BXH()
        {
            string sql = "SELECT TOP(8) * FROM nhac ORDER BY LuotNghe DESC";
            return mydb.Database.SqlQuery<nhac>(sql).ToList();
        }
        public List<nhac> GetNhacs_Play(string id)
        {
            string sql = "SELECT TOP(8) * FROM nhac  WHERE MaBH='" + id + "'";
            return mydb.Database.SqlQuery<nhac>(sql).ToList();
        }
        public List<nhac> GetList_Nhac()
        {
            string sql = "SELECT TOP(8) * FROM nhac";
            return mydb.Database.SqlQuery<nhac>(sql).ToList();
        }
        public void Xoa_thucUong(string id)
        {
            string sql = "DELETE FROM thucuong WHERE idThucUong='" + id + "'";
             mydb.Database.ExecuteSqlCommand(sql);
        }
        public void Xoa_danhMuc(string id)
        {
            string sql = "DELETE FROM danhmuc WHERE idDanhMuc='" + id + "'";
            mydb.Database.ExecuteSqlCommand(sql);
        }
        public List<chude> GetList_Chude()
        {
            return mydb.chudes.ToList();
        }
        public List<casi> GetList_Casi()
        {
            return mydb.casis.ToList();
        }
        ///public List<donhang> GetList_DonHang()
        //{
           /// return mydb.donhangs.ToList();
        //}
        public List<playlist> GetList_Playlist()
        {
            return mydb.playlists.ToList();
        }
        public void Save()
        {
            mydb.SaveChanges();
        }
        public taikhoan GetObject_User(string usn,string pw)
        {
            string sql = "SELECT * FROM taikhoan WHERE UserName='"+usn+"' AND PassWord='"+pw+"'";
            return mydb.Database.SqlQuery<taikhoan>(sql).FirstOrDefault();
        }
        public theloai GetObject_TheLoai(string id)
        {
            string sql = "SELECT * FROM theloai WHERE MaTL='" + id +"'";
            return mydb.Database.SqlQuery<theloai>(sql).FirstOrDefault();
        }

    }
}
