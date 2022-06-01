using Book.DataAccess.Data;
using Book.DataAccess.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _dbcontext;

        public CategoryRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Update(Category obj)
        {
            _dbcontext.Categories.Update(obj);
        }
    }
}
