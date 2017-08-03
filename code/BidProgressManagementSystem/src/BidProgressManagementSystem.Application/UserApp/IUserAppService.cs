using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidProgressManagementSystem.Application.UserApp
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);

    
        //UserDto InsertOrUpdate(UserDto dto);

        ///// <summary>
        ///// 根据Id集合批量删除
        ///// </summary>
        ///// <param name="ids">Id集合</param>
        //void DeleteBatch(List<Guid> ids);

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="id">Id</param>
        //void Delete(Guid id);

        ///// <summary>
        ///// 根据Id获取实体
        ///// </summary>
        ///// <param name="id">Id</param>
        ///// <returns></returns>
        //UserDto Get(Guid id);
    }
}
