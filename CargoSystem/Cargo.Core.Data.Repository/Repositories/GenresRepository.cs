using Cargo.Component.Tools;
using Cargo.Core.Data.Entity;
using Cargo.Core.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Cargo.Core.Data.Repository.Repositories
{
    public class GenresRepository : IGenresRepository
    {
        /// <summary>
        /// 数据测试
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Entity.ResponseResult Add(Entity.GenresEntity entity)
        {
            var appResult = ResponseResult.Default();
            try
            {
                using (IDbConnection conn = SessionFactory.CreateConnection())
                {
                    int rows = conn.Insert<GenresEntity>(entity);
                    if (rows > 0) appResult = ResponseResult.Success();
                }
            }
            catch(Exception ex)
            {
                appResult = ResponseResult.Error(ex.Message);
            }
            return appResult;
        }
    }
}
