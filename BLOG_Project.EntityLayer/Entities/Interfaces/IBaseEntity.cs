using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.EntityLayer.Entities.Interfaces
{
    public interface IBaseEntity<T>
    {
        T  Id { get; set; }
    }
}
