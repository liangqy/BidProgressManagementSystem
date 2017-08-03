using BidProgressManagementSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.Application.BaseApp
{
    public interface IApp
    {

    }
    public interface IApp<TEntity, TPrimaryKey> : IApp where TEntity : BaseModel<TPrimaryKey>
    {

    }
}
