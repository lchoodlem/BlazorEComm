using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEComm.Shared
{
    public class OrderOverviewResponse
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;
        public decimal TotalPrice { get; set; }
        public string Product { get; set; }
        public string ProductImageUrl { get; set; }
        
    }
}
