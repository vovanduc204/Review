using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class OrderItemSaveRequestViewModel
    {
        public int Id { get; protected set; }

        public int ProductId { get; protected set; }

        public int OrderId { get; protected set; }

        public PriceSaveRequestViewModel Price { get; set; }
    }
}
