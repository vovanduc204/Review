using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.DomainLayer.Enums
{
    public enum FilterComparisonEnum : int
    {
        [Display(Name = "Equal", ShortName = "=", GroupName = "All")]
        Equal = 0,
        [Display(Name = "Less Than", ShortName = "<", GroupName = "All")]
        LessThan = 1,
        [Display(Name = "Less Than Or Equal", ShortName = "<=", GroupName = "All")]
        LessThanOrEqual = 2,
        [Display(Name = "Greater Than", ShortName = ">", GroupName = "All")]
        GreaterThan = 3,
        [Display(Name = "Greater Than Or Equal", ShortName = ">=", GroupName = "All")]
        GreaterThanOrEqual = 4,
        [Display(Name = "Not Equal", ShortName = "<>", GroupName = "All")]
        NotEqual = 5,
        [Display(Name = "Contains", ShortName = "In", GroupName = "String")]
        Contains = 6, //for strings  
        [Display(Name = "Starts With", ShortName = "_=", GroupName = "String")]
        StartsWith = 7, //for strings  
        [Display(Name = "Ends With", ShortName = "=_", GroupName = "String")]
        EndsWith = 8,//for strings 
        [Display(Name = "Does not contains", ShortName = "<>In", GroupName = "String")]
        NotContains = 9,//for strings  
        [Display(Name = "Is Null", ShortName = "null", GroupName = "String")]
        Null = 10,//for strings  
        [Display(Name = "Is Not Null", ShortName = "<>null", GroupName = "String")]
        NotNull = 11,//for strings  
        [Display(Name = "Is Empty", ShortName = "empty", GroupName = "String")]
        Empty = 12,//for strings  
        [Display(Name = "Is Not Empty", ShortName = "<>empty", GroupName = "String")]
        NotEmpty = 13,//for strings  
        [Display(Name = "Is Has Value", ShortName = "value", GroupName = "String")]
        HasValue = 14,//for strings  
        [Display(Name = "Is Has No Value", ShortName = "<>value", GroupName = "String")]
        HasNoValue = 15 //for strings  
    }
}
