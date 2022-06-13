using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.DomainLayer.Core.Extensions
{
    public class PagingParameter
    {
        const int maxPagesize = 50;
        public int PageNumber { get; set; }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPagesize) ? maxPagesize : value;
            }
        }

    }
}
