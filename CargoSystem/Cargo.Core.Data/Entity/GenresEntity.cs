using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions.Mapper;
using System.Threading.Tasks;

namespace Cargo.Core.Data.Entity
{
   [Serializable]
    public class GenresEntity
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Genre：实体对象映射关系
    /// </summary>
    [Serializable]
    public class GenresEntityORMMapper : ClassMapper<GenresEntity>
    {
        public GenresEntityORMMapper()
        {
            base.Table(tableName: "Genres");
            Map(f => f.GenreId).Key(KeyType.Identity);//设置主键  (如果主键名称不包含字母“ID”，请设置)      
            AutoMap();
        }
    }
}
