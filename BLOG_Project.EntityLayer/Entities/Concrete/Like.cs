using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.EntityLayer.Entities.Concrete
{
    public class Like:BaseEntity
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
