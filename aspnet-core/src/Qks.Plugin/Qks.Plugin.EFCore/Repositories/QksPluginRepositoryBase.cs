using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.Plugin.EFCore.Repositories
{
    public abstract class QksPluginRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<QksPluginDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected QksPluginRepositoryBase(IDbContextProvider<QksPluginDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // 要在这里添加公共方法
    }

    public abstract class QksPluginRepositoryBase<TEntity> : QksPluginRepositoryBase<TEntity, int>, IRepository<TEntity>
       where TEntity : class, IEntity<int>
    {
        protected QksPluginRepositoryBase(IDbContextProvider<QksPluginDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //不要在这里添加公共方法
    }
}
