using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerPhNum { get; set; }
        public string CustumerName { get; set; }
        public List<int> ItemsIds { get; set; }
    }
}
