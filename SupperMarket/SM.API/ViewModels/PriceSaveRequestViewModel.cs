using SM.DomainLayer.Enums;

namespace SM.API.ViewModels
{
    public class PriceSaveRequestViewModel
    {
        /// <example>100</example>
        public int? Amount { get; set; }

        /// <example>MoneyUnit.Rial</example>
        public MoneyUnit? Unit { get; set; } = MoneyUnit.UnSpecified;
    }
}