using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class Product
    {
        
        public int ProductID { get; set; }

        [DisplayName("Computer ID")]
        public string ProductCode { get; set; }

        [DisplayName("Computer Name")]
        public string ProductName { get; set; }

        [DisplayName("Windows Version")]
        public decimal ProductVersion { get; set; }

        [DisplayName("Last Successful Update")]
        public DateTime ProductReleaseDate { get; set; }
    }
}