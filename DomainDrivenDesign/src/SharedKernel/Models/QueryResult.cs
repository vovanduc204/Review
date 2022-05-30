using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Models
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Entities { get; set; }
        public int TotalCount { get; set; }

        public QueryResult()
        {

        }

        public QueryResult(IEnumerable<T> entities, int totalCount)
        {
            TotalCount = totalCount;

            Entities = entities;
        }
    }
}
