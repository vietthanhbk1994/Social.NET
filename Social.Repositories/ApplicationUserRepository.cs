using Social.Data.Model;
using Social.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repositories
{
    public interface IApplicationUserRepository : IRepositoryBase<ApplicationUser>
    {

    }
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(SocialContext dbContext) : base(dbContext)
        {
        }
    }
}
