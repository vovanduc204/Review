using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class OrderItemSaveRequestViewModel
    {
        public int? ProductId { get; set; }

        public PriceSaveRequestViewModel Price { get; set; }
    }
}
