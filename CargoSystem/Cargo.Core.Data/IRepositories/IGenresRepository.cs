using Cargo.Core.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Core.Data.IRepositories
{
    public interface IGenresRepository
    {
        ResponseResult Add(GenresEntity entity);
    }
}
