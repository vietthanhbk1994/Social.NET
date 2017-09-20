using Social.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Mapping
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public SocialContext DbContext { get; }
        public UnitOfWork(SocialContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
