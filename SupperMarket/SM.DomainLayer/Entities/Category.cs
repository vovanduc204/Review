using SM.DomainLayer.Core.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class Category : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IList<Product> Products { get; private set; } = new List<Product>();

        public Category(string name)
        {
            Name = name;
        }


    }
}
