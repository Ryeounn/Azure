using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Sneker.Models
{
    public class cart_item
    {
        public Product product { get; set; }
        public decimal? quantity { get; set; }
    }

    public class Cart
    {
        List<cart_item> items = new List<cart_item>();
        public IEnumerable<cart_item> Items
        {
            get { return items; }
        }

        public void Add(Product product, int ql = 1)
        {
            var item = items.FirstOrDefault(x => x.product.ProductID == product.ProductID && x.product.Quantityperunit >= ql);
            if (item == null)
            {
                items.Add(item = new cart_item
                {
                    product = product,
                    quantity = ql,
                });
            }
            else
            {
                item.quantity += ql;
            }
        }

        public void Update_Quantity_Shopping(int id, int quantity)
        {
            var item = items.Find(s => s.product.ProductID == id);
            if (item != null)
            {
                item.quantity = quantity;
            }
        }

        public List<Product> select_cart()
        {
            var model = db.Products.ToList();

            //var name= model.FirstOrDefault().Name;
            //var price = db.Ticket.FirstOrDefault(s => s.Name == name);
            //if (price != null)
            //{
            // price.Price = model.FirstOrDefault().Price;
            //}
            return model;
        }

        public List<Product> select_price(string Name, decimal Price)
        {


            var price = db.Products.Where(x => x.Productname.Equals(Name)).FirstOrDefault();
            if (price != null)
            {
                price.Unitprice = Price;
            }
            return select_price(Name, Price);
        }
        SnekerEntities db = new SnekerEntities();
        public decimal? Total_money()
        {
            var money = items.Sum(s => s.quantity * s.product.Unitprice);
            return (decimal)money;
        }

        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s.product.ProductID == id);
        }
    }
}