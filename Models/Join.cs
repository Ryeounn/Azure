using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneker.Models
{
    public class Join
    {
        public int Id { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int SizeID { get; set; }
        public int Sizes { get; set; }
        public int UnitinStock { get; set; }
        public int Unitpirce {  get; set; }
        public int Discount { get; set; }
        public int CateID { get; set; }
        public string CateName { get; set; }
        public string CatePicture { get; set;}
        public string CatePicturePath { get; set; }

    }

    public class Functions
    {
        public SnekerEntities db = new SnekerEntities();
        public List<Join> Nikes()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         let size = a.Sizer
                         where a.ProductID == 4 || a.ProductID == 10 || a.ProductID == 12 || a.ProductID == 20
                         select new Join()
                         {
                             Id = a.ProductID,
                             Code = a.Productcode,
                             Name = a.Productname,
                             Description = cate.Description,
                             Quantity = (int)a.Quantityperunit,
                             UnitinStock = (int)a.Unitinstock,
                             Unitpirce = (int)a.Unitprice,
                             Discount = (int)a.Discount,
                             CateID = cate.CaterogiesID,
                             CateName = cate.Caterogyname,
                             CatePicture = a.Picture,
                             CatePicturePath = a.PicturePath
                         }).ToList();
            return model;
        }

        public List<Join> Adidas()
        {
            var model = (from a in db.Products
                         join b in db.Categories on a.CaterogyID equals b.CaterogiesID
                         where a.ProductID == 13 || a.ProductID == 14 || a.ProductID == 15 || a.ProductID == 22
                         select new Join()
                         {
                             Id = a.ProductID,
                             Code = a.Productcode,
                             Name = a.Productname,
                             Description = b.Description,
                             Quantity = (int)a.Quantityperunit,
                             UnitinStock = (int)a.Unitinstock,
                             Unitpirce = (int)a.Unitprice,
                             Discount = (int)a.Discount,
                             CateID = b.CaterogiesID,
                             CateName = b.Caterogyname,
                             CatePicture = a.Picture,
                             CatePicturePath = a.PicturePath
                         }).ToList();
            return model;
        }

        public List<Join> Puma()
        {
            var model = (from a in db.Products
                         join b in db.Categories on a.CaterogyID equals b.CaterogiesID
                         where a.ProductID == 13 || a.ProductID == 14 || a.ProductID == 15 || a.ProductID == 22
                         select new Join()
                         {
                             Id = a.ProductID,
                             Code = a.Productcode,
                             Name = a.Productname,
                             Description = b.Description,
                             Quantity = (int)a.Quantityperunit,
                             UnitinStock = (int)a.Unitinstock,
                             Unitpirce = (int)a.Unitprice,
                             Discount = (int)a.Discount,
                             CateID = b.CaterogiesID,
                             CateName = b.Caterogyname,
                             CatePicture = a.Picture,
                             CatePicturePath = a.PicturePath
                         }).ToList();
            return model;
        }

        public List<Join> Converse()
        {
            var model = (from a in db.Products
                         join b in db.Categories on a.CaterogyID equals b.CaterogiesID
                         where a.ProductID == 13 || a.ProductID == 14 || a.ProductID == 15 || a.ProductID == 22
                         select new Join()
                         {
                             Id = a.ProductID,
                             Code = a.Productcode,
                             Name = a.Productname,
                             Description = b.Description,
                             Quantity = (int)a.Quantityperunit,
                             UnitinStock = (int)a.Unitinstock,
                             Unitpirce = (int)a.Unitprice,
                             Discount = (int)a.Discount,
                             CateID = b.CaterogiesID,
                             CateName = b.Caterogyname,
                             CatePicture = a.Picture,
                             CatePicturePath = a.PicturePath
                         }).ToList();
            return model;
        }
    }
}