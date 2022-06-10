using SM.DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Comunication.Response
{
    public class CategoryResponse: BaseResponse<Product>
    {
        public CategoryResponse(Product category) : base(category)
        {

        }

        public CategoryResponse(string message) : base(message)
        { }

    }
}
