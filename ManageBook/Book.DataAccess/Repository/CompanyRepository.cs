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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _dbcontext;

        public CompanyRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public void Update(Company obj)
        {
            _dbcontext.Companies.Update(obj);
        }
    }
}
