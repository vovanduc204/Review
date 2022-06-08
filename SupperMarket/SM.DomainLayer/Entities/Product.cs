using SM.DomainLayer.Core.SharedKernel.Models;
using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Entities
{
    public class Product : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name , short quantityInPackage, int categoryId, EUnitOfMeasurement unitOfMeasurement)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            CategoryId = categoryId;
            UnitOfMeasurement = unitOfMeasurement;
        }

        protected Product()
        {
        }

        // unit test
        public Product(int id, string name, short quantityInPackage, EUnitOfMeasurement unitOfMeasurement, int categoryId)
        {
            Id = id;
            Name = name;
            QuantityInPackage = quantityInPackage;
            UnitOfMeasurement = unitOfMeasurement;
            CategoryId = categoryId;
        }
    }
}
