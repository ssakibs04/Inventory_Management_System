//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inventory_ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        public int id { get; set; }
        public string Purchase_product { get; set; }
        public string Purchase_pnty { get; set; }
        public System.DateTime Purchase_date { get; set; }
        public Nullable<int> unit_price { get; set; }
        public Nullable<int> total_price { get; set; }
		public string Sale_pnty { get; internal set; }
		public string Sale_product { get; internal set; }
	}
}
