using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Comunication.Request
{
    public class ProductsRequest :Query
    {
        public int? CategoryId { get; set; }

        public ProductsRequest(int? categoryId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            CategoryId = categoryId;
        }
    }
}
