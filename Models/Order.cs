//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sneker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public Nullable<System.DateTime> Orderdate { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public string Shipcountry { get; set; }
        public string Status { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}