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
        public int Size { get; set; }
        public int UnitinStock { get; set; }
        public int Unitpirce {  get; set; }
        public int Discount { get; set; }
        public int CateID { get; set; }
        public string CateName { get; set; }
        public string Picture { get; set;}
        public string PicturePath { get; set; }

    }

    public class Collection
    {
        public SnekerEntities db = new SnekerEntities();
        public List<Join> Nikes()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 9 || a.ProductID == 13 || a.ProductID == 15 || a.ProductID == 16
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Adidas()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 1 || a.ProductID == 3 || a.ProductID == 5 || a.ProductID == 8
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Puma()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 17 || a.ProductID == 21 || a.ProductID == 22 || a.ProductID == 24
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Converse()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 25 || a.ProductID == 28 || a.ProductID == 30 || a.ProductID == 32
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> All()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 9 || a.ProductID == 13 || a.ProductID == 15 || a.ProductID == 16 || a.ProductID == 1 || a.ProductID == 3 || a.ProductID == 5 || a.ProductID == 8 || a.ProductID == 17 || a.ProductID == 21 || a.ProductID == 22 || a.ProductID == 24 || a.ProductID == 25 || a.ProductID == 28 || a.ProductID == 30 || a.ProductID == 32
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }
    }

    public class Functions
    {
        public SnekerEntities db = new SnekerEntities();
        public List<Join> Nikes()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 10 || a.ProductID == 13 || a.ProductID == 15 || a.ProductID == 16
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Adidas()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 1 || a.ProductID == 3 || a.ProductID == 5 || a.ProductID == 8
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Puma()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 17 || a.ProductID == 21 || a.ProductID == 22 || a.ProductID == 24
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }

        public List<Join> Converse()
        {
            var model = (from a in db.Products
                         let cate = a.Category
                         where a.ProductID == 25 || a.ProductID == 28 || a.ProductID == 30 || a.ProductID == 32
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
                             Picture = a.Picture,
                             PicturePath = a.PicturePath,
                             Size = (int)a.Size
                         }).ToList();
            return model;
        }
    }
}