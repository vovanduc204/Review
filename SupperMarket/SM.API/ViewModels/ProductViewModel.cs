using SM.DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; private set; }

        public int CategoryId { get; private set; }
    }

    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public short Quantity { get; set; }
        public byte Unit { get; set; }
        public byte UnitOfMeasurement { get; set; }
        public int CategoryId { get; set; }
    }
}
