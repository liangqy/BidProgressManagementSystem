using System;
using System.Collections.Generic;
using System.Text;


namespace BidProgressManagementSystem.EntityFramework
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
