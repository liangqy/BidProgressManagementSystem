
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.EntityFramework
{
    public interface IDepartmentRepository : IRepository<Department, Guid>
    {
    }
}
